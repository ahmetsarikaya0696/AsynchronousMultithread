﻿#region ContinueWith
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

#region WhenAny
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

//var firstData = await Task.WhenAny(taskList);
//Console.WriteLine($"First Data : {firstData.Result.Site}");
#endregion

#region WaitAll
//// WhenAll metodu ana threadi bloklamaz fakat WailAll metodu ana threadi bloklar.
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
//Console.WriteLine("WaitAll metodundan önce");
////Task.WaitAll(taskList.ToArray());
//bool isWaitAllSuccessfull = Task.WaitAll(taskList.ToArray(), 1000);
//Console.WriteLine($"WaitAll metodundan sonra\r\nisSuccess = {isWaitAllSuccessfull}");
//Console.WriteLine($"First Data : {taskList.First().Result.Site}");
#endregion

#region WaitAny
//// Çağrıldığı threadi bloklar
//using TaskConsoleApp;

//Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");
//List<string> urlList = new()
//{
//    "https://www.google.com",
//    "https://www.amazon.com",
//    "https://www.n11.com",
//    "https://www.haberturk.com"
//};

//List<Task<Content>> taskList = new();
//urlList.ToList().ForEach(url =>
//{
//    taskList.Add(StaticMethods.GetContentAsync(url));
//});

//int firstCompletedTaskIndex = Task.WaitAny(taskList.ToArray());
//Console.WriteLine($"First Completed Task : {taskList[firstCompletedTaskIndex].Result.Site}");
#endregion

#region Delay
// Threadi bloklamaz
//Task.Delay(1000);
#endregion