using System;
using System.Collections.Generic;
using System.Text;

namespace Localiza.Frotas.Domain
{
    public interface IVeiculoRepository
    {
        Veiculo GetById(Guid Id);
        IEnumerable<Veiculo> GetAll();
        void Add(Veiculo veiculo);
        void Delete(Veiculo veiculo);
        void Update(Veiculo veiculo);
    }
}
