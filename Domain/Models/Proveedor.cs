using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;

namespace Domain.Models;

public class Proveedor: IValidable, IIdentityById, ICopiable<Proveedor>
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public void Validar()
    {
       Util.ThrowExceptionIfEmptyString(Nombre, "Falta el nombre del proveedor");
    }

    public void Copy(Proveedor model)
    {
        Nombre = model.Nombre;
    }
}
