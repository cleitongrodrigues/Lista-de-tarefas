using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity> // O ABSTRACT É UMA CLASSE QUE NÃO PODE SER INSTANCIADA, MAS PODE SER HERDADA POR OUTRAS CLASSES (BASE - COMUM)
    {
        // O IEQUATABLE É UMA INTERFACE QUE PERMITE COMPARAR OBJETOS DE UMA CLASSE, NESSE CASO, A CLASSE ENTITY
        public Guid Id { get; private set; }

        protected Entity() // O PROTECTED É UM MODIFICADOR DE ACESSO QUE PERMITE QUE A CLASSE SEJA ACESSADA POR CLASSES FILHAS, MAS NÃO POR OUTRAS CLASSES
        {
            Id = Guid.NewGuid(); // GERA UM NOVO ID PARA CADA ENTIDADE
        }

        public bool Equals(Entity? other)
        {
            return Id == other?.Id;
        }
    }
}