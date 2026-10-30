var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var listaVeiculos = new List<Veiculo>();

app.MapGet("/", () => "Minimal API em Execucao");

app.MapGet("/veiculos", () => Results.Ok(listaVeiculos));

app.MapPost("/veiculos", (Veiculo veiculo) =>
{
    listaVeiculos.Add(veiculo);
    return Results.Created($"/veiculos/{veiculo.Id}", veiculo);
});

app.Run();

record Veiculo(int Id, string Nome, string Marca, int Ano);