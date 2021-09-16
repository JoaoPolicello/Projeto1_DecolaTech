using System.Collections.Generic;

namespace CatalogoSpotifai.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId( int id);        
        void Insere( T entidade);        
        void Exclui( int id);        
        void Atualiza( int id, T entidade);
        void Avalia( int id, double avaliacao);
        int ProximoId();
    }
}