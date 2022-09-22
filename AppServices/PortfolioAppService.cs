using AppServices.Interfaces;
using AppServices.Mappers.Portfolio.Requests;
using AppServices.Mappers.Portfolio.Responses;
using AutoMapper;
using DomainModels;
using DomainServices.Exceptions;
using DomainServices.Interfaces;
using System;

namespace AppServices
{
    public class PortfolioAppService : IPortfolioAppService
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioService _portfolioService;
        private readonly ICustomerService _customerService;

        public PortfolioAppService(IMapper mapper, IPortfolioService portfolioService, ICustomerService customerService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _portfolioService = portfolioService ?? throw new ArgumentNullException(nameof(portfolioService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
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

        public GetPortfolioByIdPortfolioResponse GetByIdPortfolio(int idPortfolio)
        {
            var portfolio = _portfolioService.GetByIdPortfolio(idPortfolio);
            return _mapper.Map<GetPortfolioByIdPortfolioResponse>(portfolio);
        }
    }
}
