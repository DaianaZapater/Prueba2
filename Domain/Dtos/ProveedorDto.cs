using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Utils;

namespace Domain.Dtos;

public class ProveedorDto: IValidable, IIdentityById
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public void Validar()
    {
        Util.ThrowExceptionIfEmptyString(Nombre, "Falta el nombre del proveedor");
    }
}
