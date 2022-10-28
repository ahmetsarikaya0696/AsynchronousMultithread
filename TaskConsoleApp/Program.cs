#region ContinueWith
//using TaskConsoleApp;

////var myTask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith((data) =>
////{
////    Console.WriteLine(data.Result.Length);
////});

//var myTask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith((data) =>
//{
//	StaticMethods.Callback(data);
//});

//Console.WriteLine("Arada yapılacak işler");

//await myTask; 
#endregion

#region WhenAll
//using TaskConsoleApp;

//Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");
//List<string> urlList = new()
//{
//    "https://www.google.com",
//    "https://www.microsoft.com",
//    "https://www.amazon.com",
//    "https://www.n11.com",
//    "https://www.haberturk.com"
//};

//List<Task<Content>> taskList = new();
//urlList.ToList().ForEach(url =>
//{
//    taskList.Add(StaticMethods.GetContentAsync(url));
//});

//var contents = await Task.WhenAll(taskList.ToArray());

//contents.ToList().ForEach(content =>
//{
//    Console.WriteLine($"Site:{content.Site} Length:{content.Len}");
//}); 
#endregion