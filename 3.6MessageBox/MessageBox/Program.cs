namespace MessageBoxHomeTask
{
    internal sealed class Program
    {
        public static async Task Main(string[] args)
        {
            var source = new TaskCompletionSource();
            MessageBox messageBox = new MessageBox();
            messageBox.WindowBeenClosed += (state) =>
            {
                Console.WriteLine($"State: {state}");
                HandelWindowsClosedResult(state);
                source.SetResult();
            };

            messageBox.Open();
            await source.Task;
        }

        private static void HandelWindowsClosedResult(StateEnum state)
        {
            switch (state)
            {
                case StateEnum.Ok:
                    Console.WriteLine("The operation has been confirmed.");
                    break;
                case StateEnum.Cancel:
                    Console.WriteLine("The operation was rejected.");
                    break;
            }
        }
    }
}