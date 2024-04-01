namespace Pokemon.Core.Entities.Business
{
    public class ListPokemon
    {
        public required IEnumerable<Business.Pokemon> Pokemons { get; set; }

    }

}