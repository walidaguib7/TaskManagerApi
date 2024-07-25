using Microsoft.AspNetCore.Mvc.Filters;

namespace TasksApi.Filters
{
    public class MyLogging(string caller) :Attribute, IActionFilter
    {
        private readonly string _caller = caller;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"filter after executing {_caller}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"filter before executing {_caller}");
        }
    }
}
