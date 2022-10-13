using AppServices.Interfaces;
using AppServices.Mappers.Portfolio.Requests;
using AppServices.Mappers.Portfolio.Responses;
using AutoMapper;
using DomainModels;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using System;
using System.Linq;

namespace AppServices
{
    public class PortfolioAppService : IPortfolioAppService
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioService _portfolioService;
        private readonly ICustomerService _customerService;
        private readonly ICustomerBankInfoService _customerBankInfoService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public PortfolioAppService(IMapper mapper, IPortfolioService portfolioService, ICustomerService customerService, ICustomerBankInfoService customerBankInfoService, IProductService productService, IOrderService orderService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _portfolioService = portfolioService ?? throw new ArgumentNullException(nameof(portfolioService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _customerBankInfoService = customerBankInfoService ?? throw new ArgumentNullException(nameof(customerBankInfoService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
        public int Create(CreateNewPortfolioRequest request)
        {
            if (_customerService.CustomerExists(request.CustomerId))
            {
                var portfolio = _mapper.Map<Portfolio>(request);
                return _portfolioService.Create(portfolio);
            }
            else
            {
                throw new PortfolioDatabaseValidationException($"Nenhum usuário encontrado para o id {request.CustomerId}");
            }
        }

        public void ProcessDepositRequest(DepositRequest request)
        {
            var customer = _customerService.GetById(request.CustomerId);
            if (customer == null) throw new PortfolioDatabaseValidationException($"Não foi encontrado nenhum cliente para o id {request.CustomerId}");
            var portfolio = _portfolioService.GetByIdPortfolio(request.PortfolioId);
            if (portfolio == null || customer.BankInfo.AccountBalance < request.Amount)
                _customerBankInfoService.DepositValue(customer.BankInfo, request.Amount);
            else
            {
                _customerBankInfoService.WithdrawValue(customer.BankInfo, request.Amount);
                _portfolioService.Deposit(portfolio, request.Amount);
            }
        }

        public void ProcessWithdrawRequest(WithdrawBalanceRequest withdrawRequest)
        {
            var customer = _customerService.GetById(withdrawRequest.CustomerId);
            if (customer == null) throw new PortfolioDatabaseValidationException($"Não foi encontrado nenhum cliente para o id {withdrawRequest.CustomerId}");
            var portfolio = _portfolioService.GetByIdPortfolio(withdrawRequest.PortfolioId) ?? throw new PortfolioDatabaseValidationException($"Portfólio não encontrado");
            if(portfolio.TotalBalance < withdrawRequest.Amount) throw new PortfolioDatabaseValidationException($"Saldo insuficiente");
            else
            {
                DebitFromPortfolio(portfolio, withdrawRequest.Amount);
                _customerBankInfoService.DepositValue(customer.BankInfo, withdrawRequest.Amount);
            }
        }

        public GetPortfolioByIdPortfolioResponse GetByIdPortfolio(int idPortfolio)
        {
            var portfolio = _portfolioService.GetByIdPortfolio(idPortfolio);
            return _mapper.Map<GetPortfolioByIdPortfolioResponse>(portfolio);
        }

        public void ProcessInvestmentRequest(InvestmentRequest request, OrderDirection direction)
        {
            var portfolio = _portfolioService.GetByIdPortfolio(request.PortfolioId);
            var product = _productService.GetById(request.ProductId);
            var order = _mapper.Map<Order>(request);
            TryValidateInvestmentRequest(portfolio, product);
            switch (direction)
            {
                case OrderDirection.Buy:
                    ProcessBuyInvestmentRequest(portfolio, product, order);
                    break;
                case OrderDirection.Sell:
                    ProcessSellInvestmentRequest(portfolio, product, order);
                    break;
                default:
                    throw new InvalidOperationException("Investimento pode ser apenas de compra ou venda.");
            }
        }

        public void Delete(int idPortfolio)
        {
            var portfolio = _portfolioService.GetByIdPortfolio(idPortfolio) ?? throw new PortfolioDatabaseValidationException($"Nenhum portfólio encontrado para o id {idPortfolio}");
            if(portfolio.TotalBalance == 0)
                _portfolioService.Delete(portfolio);
            else
                throw new PortfolioDatabaseValidationException($"Não é possível excluir uma carteira com saldo diferente de 0");
        }

        private void ProcessBuyInvestmentRequest(Portfolio portfolio, Product product, Order order)
        {
            if (portfolio.TotalBalance < order.NetValue)
                throw new PortfolioDatabaseValidationException($"Saldo insuficiente na carteira.");
            order.Direction = OrderDirection.Buy;
            _orderService.Add(order);
            DebitFromPortfolio(portfolio, order.NetValue);
            AddProductToPortfolio(product, portfolio);
        }

        private void ProcessSellInvestmentRequest(Portfolio portfolio, Product product, Order order)
        {
            order.Direction = OrderDirection.Sell;
            var position = _orderService.GetSpecificProductPosition(product.Id, portfolio.Id);
            if (position < order.Quotes)
                throw new PortfolioDatabaseValidationException($"Quantidade de resgate maior do que a posição");
            _orderService.Add(order);
            if (position - order.Quotes == 0)
            {
                RemoveProductFromPortfolio(product, portfolio);
            }
            DepositOnPortfolio(portfolio, order.NetValue);
        }

        private void DebitFromPortfolio(Portfolio portfolio, decimal value)
        {
            portfolio.Debit(value);
            _portfolioService.Update(portfolio);
        }

        private void DepositOnPortfolio(Portfolio portfolio, decimal value)
        {
            portfolio.Deposit(value);
            _portfolioService.Update(portfolio);
        }

        private void RemoveProductFromPortfolio(Product product, Portfolio portfolio)
        {
            var productToDelete = portfolio.Products.SingleOrDefault(existingProduct => existingProduct.Id.Equals(product.Id));
            if (productToDelete != null)
            {
                portfolio.Products.Remove(productToDelete);
            }
            _portfolioService.Update(portfolio);
        }

        private void TryValidateInvestmentRequest(Portfolio portfolio, Product product)
        {
            if (portfolio == null) throw new PortfolioDatabaseValidationException($"Carteira não encontrada.");
            if (product == null) throw new PortfolioDatabaseValidationException($"Produto não cadastrado.");
        }

        private void AddProductToPortfolio(Product product, Portfolio portfolio)
        {
            if (!portfolio.Products.Any(existingProduct => existingProduct.Id.Equals(product.Id)))
            {
                portfolio.Products.Clear();
                portfolio.Products.Add(product);
            }
            _portfolioService.Update(portfolio);
        }

    }
}
