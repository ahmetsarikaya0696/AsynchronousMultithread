using TaskConsoleApp;

//var myTask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith((data) =>
//{
//    Console.WriteLine(data.Result.Length);
//});

var myTask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith((data) =>
{
    Callback.Work(data);
});

Console.WriteLine("Arada yapılacak işler");

await myTask;