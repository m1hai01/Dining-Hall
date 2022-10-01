using Dining_Hall.Models;

namespace Dining_Hall.Services
{
    public class DiningHall : IHall
    {
        static int waiter_id = 1;
        static int order_id = 1;
        private int[] tables = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        private int[] items = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        private int[] priority = new[] {1, 2, 3, 4, 5};
        private Random rnd;
        private HttpClient httpClient;


        public DiningHall()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://host.docker.internal:8081/");
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => GenerateOrder());
            }
        }
        public void GenerateOrder()
        {
            rnd = new Random();
            var priority = this.priority[rnd.Next(0, 6)];
            var tables = this.tables[rnd.Next(0, 11)];
            var nr_items = rnd.Next(1, 6);
            int[] order_items = new int[nr_items];

            for (int i = 0; i < nr_items; i++)
            {
                order_items[i] = items[rnd.Next(0, 11)];
            }
            while (true)
            {
                var order = new Order
                {
                    waiter_id = waiter_id,
                    order_id = order_id++,
                    priority = priority,
                    items = order_items,
                    table_id = tables,
                    max_wait = rnd.Next(1, 50)

                };
                SendOrder(order);
            }
        }

        public void SendOrder(Order order)
        {
            //httpClient.PostAsync()
        }

        
    }
}
