using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Extensions
{
    public static class AddControllerExtension
    {
        public static IActionResult CatchErrors(this Controller controller,AggregateException exception)
        {
            HashSet<string> errors = new HashSet<string>();

            foreach (var error in exception.InnerExceptions) errors.Add(error.Message);

            return controller.View("./Error", errors);
        }
    }
}
