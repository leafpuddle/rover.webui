using Npgsql;

public static class QueryModelCards
{
    public static async Task<ModelCard[]> GetCards
    (
        string? id = null,
        string? name = null,
        string? desc = null,
        short? rarity = null,
        short? series = null,
        int? value = null,
        bool search = false

    )
    {
        await using NpgsqlConnection conn = new NpgsqlConnection(Database.connString);
        await conn.OpenAsync();

        string query = "SELECT tcg_cards.id, tcg_cards.name, description, tcg_rarities.name, tcg_series.name, value FROM tcg_cards";

        query += " INNER JOIN tcg_rarities ON tcg_cards.rarity = tcg_rarities.id";
        query += " INNER JOIN tcg_series ON tcg_cards.series = tcg_series.id";

        if(id != null || name != null || desc != null || rarity != null || series != null || value != null)
        {
            query += " WHERE ";
            List<string> arguments = new List<string>();

            if(id != null) arguments.Add("tcg_cards.id = $1");
            if(name != null) arguments.Add("tcg_cards.name = $2");
            if(desc != null) arguments.Add("description LIKE $3");
            if(rarity != null) arguments.Add("rarity = $4");
            if(series != null) arguments.Add("series = $5");
            if(value != null) arguments.Add("value = $6");

            query += string.Join(search ? " OR " : " AND ", arguments.ToArray());
        }

        query += " ORDER BY tcg_cards.id ASC";

        await using var cmdGetCards = new NpgsqlCommand(query, conn)
        {
            Parameters =
            {
                new() { Value = id ?? "" },
                new() { Value = name ?? "" },
                new() { Value = "%" + desc + "%" },
                new() { Value = rarity ?? 0 },
                new() { Value = series ?? 0 },
                new() { Value = value ?? 0 }
            }
        };
        await cmdGetCards.PrepareAsync();
        await using var reader = await cmdGetCards.ExecuteReaderAsync();

        List<ModelCard> cards = new List<ModelCard>();

        while (await reader.ReadAsync())
        {
            cards.Add(new ModelCard
            {
                id = reader.GetString(0),
                name = reader.GetString(1),
                description = reader.GetString(2),
                rarity = reader.GetString(3),
                series = reader.GetString(4),
                value = (int)reader.GetValue(5)
            });
        }

        await conn.CloseAsync();

        return cards.ToArray();
    }
}