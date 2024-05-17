using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using WebApiNative.Handlers.Queries.GetProductsHandler;

namespace WebApiNative.Validations
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductsQuery>
    {
        public GetProductsRequestValidator()
        {
            // Validar que el nombre y el apellido no sean iguales
            RuleFor(getProduct => getProduct)
                .Must(getProduct => getProduct.PrecioInicial <= getProduct.PrecioFinal)
                .Must(getProduct => !getProduct.Nombre.IsNullOrEmpty() || (getProduct.PrecioInicial.HasValue && getProduct.PrecioFinal.HasValue))
                .WithMessage("Debe enviar un nombre o un rango de precios valido");
        }
    }
}
