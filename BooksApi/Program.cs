using BooksApi.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddHttpClient<IBookService, BookService>();

var app = builder.Build();

app.MapControllers();

app.Run();

