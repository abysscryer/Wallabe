using Microsoft.EntityFrameworkCore;
using System;
using Wallabe.Domains;

namespace Wallabe.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Player>().HasData(
                new Player
                {
                    Id = "c09c1133-242d-43f8-9ce6-afac824b88c0",
                    Name = "이니",
                    ImagePath = "748960dc-70cd-4d9d-a470-3f9445d89183",
                    Cash = 100000000
                }, 
                new Player
                {
                    Id = "8558b62a-7e15-4083-b6d7-cd199839fd31",
                    Name = "혀니",
                    ImagePath = "248528e4-f59e-445e-9899-6c8d465c5479",
                    Cash = 100000000
                });

            builder.Entity<Crane>().HasData(
                new Crane
                {
                    Id= "42ba9d7d-62ba-4958-87a7-1bef9df38674",
                    Name = "원피스",
                    Status = PlayStatus.Ready,
                    ImagePath = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Crane
                {
                    Id = "ce7ea78e-56d6-49db-bb84-4165e3c958e9",
                    Name = "포켓몬",
                    Status = PlayStatus.Ready,
                    ImagePath = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                });

            builder.Entity<Doll>().HasData(
                new Doll
                {
                    Id = "61c59cb6-1ba6-4a3a-9d89-e9f0c6504ef6",
                    Name="루피",
                    Quantity = 10,
                    ImagePath = "61c59cb6-1ba6-4a3a-9d89-e9f0c6504ef6",
                    OnCreated = new DateTime(2019, 8, 22, 12, 5, 00, 000, DateTimeKind.Local),
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Doll
                {
                    Id = "c69a518d-1dc5-4939-91cb-4dec75c08733",
                    Name = "조로",
                    Quantity = 10,
                    ImagePath = "c69a518d-1dc5-4939-91cb-4dec75c08733",
                    OnCreated = new DateTime(2019, 8, 22, 12, 10, 00, 000, DateTimeKind.Local),
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Doll
                {
                    Id = "c3e7202c-c7cc-4e18-b8dc-2c4f259e7aa2",
                    Name = "피카츄",
                    Quantity = 10,
                    ImagePath = "c3e7202c-c7cc-4e18-b8dc-2c4f259e7aa2",
                    OnCreated = new DateTime(2019, 8, 22, 12, 15, 00, 000, DateTimeKind.Local),
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                },
                new Doll
                {
                    Id = "e5bdc11d-9194-4e06-a1dc-a33226512692",
                    Name = "파이리",
                    Quantity = 10,
                    ImagePath = "e5bdc11d-9194-4e06-a1dc-a33226512692",
                    OnCreated = new DateTime(2019, 8, 22, 12, 20, 00, 000, DateTimeKind.Local),
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                });

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = "b9fe5e69-cc69-4354-b0ff-557c54392a21",
                    Quantity = 1,
                    Cash = 1000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 1, 00, 000, DateTimeKind.Local),
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Product
                {
                    Id = "d25830d7-1523-487e-86ea-bdb9ce224d59",
                    Quantity = 2,
                    Cash = 2000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 1, 00, 000, DateTimeKind.Local),
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Product
                {
                    Id = "d17babcb-ab39-4fd9-9f2e-8ae4529e92a0",
                    Quantity = 3,
                    Cash = 3000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 3, 00, 000, DateTimeKind.Local),
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Product
                {
                    Id = "b59a1e20-f31e-4d0f-a72e-489013ce7170",
                    Quantity = 4,
                    Cash = 4000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 4, 00, 000, DateTimeKind.Local),
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Product
                {
                    Id = "efdf197e-cd23-4b44-9cbe-caac4809309d",
                    Quantity = 5,
                    Cash = 5000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 5, 00, 000, DateTimeKind.Local),
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674"
                },
                new Product
                {
                    Id = "d57567b0-cb03-4410-a517-383ca9880904",
                    Quantity = 1,
                    Cash = 1000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 6, 00, 000, DateTimeKind.Local),
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                },
                new Product
                {
                    Id = "46aeb3db-80ab-437d-9b34-4e553633461e",
                    Quantity = 2,
                    Cash = 2000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 7, 00, 000, DateTimeKind.Local),
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                },
                new Product
                {
                    Id = "c7c8de70-b9c1-4df0-8520-340c16e1f585",
                    Quantity = 3,
                    Cash = 3000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 8, 00, 000, DateTimeKind.Local),
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                },
                new Product
                {
                    Id = "f1afa3d7-4df8-4766-92be-e522110f7dae",
                    Quantity = 4,
                    Cash = 4000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 9, 00, 000, DateTimeKind.Local),
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                },
                new Product
                {
                    Id = "7da6f8d6-eb6a-4466-8b1b-cb7d470d88b8",
                    Quantity = 5,
                    Cash = 5000,
                    OnCreated = new DateTime(2019, 8, 22, 12, 10, 00, 000, DateTimeKind.Local),
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9"
                });

            builder.Entity<Order>().HasData(
                new Order
                {
                    Id = "b3fb6608-5597-4cbf-8cd1-ba74399ee308",
                    PlayerId = "c09c1133-242d-43f8-9ce6-afac824b88c0",
                    ProductId = "b9fe5e69-cc69-4354-b0ff-557c54392a21",
                    OnCreated = new DateTime(2019, 8, 22, 12, 15, 00, 000, DateTimeKind.Local)
                },
                new Order
                {
                    Id = "b3592c2e-6e78-4ebe-a494-ae00e5dbaeeb",
                    PlayerId = "c09c1133-242d-43f8-9ce6-afac824b88c0",
                    ProductId = "d57567b0-cb03-4410-a517-383ca9880904",
                    OnCreated = new DateTime(2019, 8, 22, 12, 20, 00, 000, DateTimeKind.Local)
                },
                new Order
                {
                    Id = "516dab55-308c-4741-af35-7733c316dbd2",
                    PlayerId = "8558b62a-7e15-4083-b6d7-cd199839fd31",
                    ProductId = "b9fe5e69-cc69-4354-b0ff-557c54392a21",
                    OnCreated = new DateTime(2019, 8, 22, 12, 25, 00, 000, DateTimeKind.Local)
                },
                new Order
                {
                    Id = "58b773a5-2bb7-4106-a510-d4ab8ac0bbad",
                    PlayerId = "8558b62a-7e15-4083-b6d7-cd199839fd31",
                    ProductId = "d57567b0-cb03-4410-a517-383ca9880904",
                    OnCreated = new DateTime(2019, 8, 22, 12, 30, 00, 000, DateTimeKind.Local)
                });

            builder.Entity<Game>().HasData(
                new Game
                {
                    Id = "322173e1-9821-4026-a0c2-cecd97ea3f64",
                    Status = PlayStatus.Over,
                    State = PlayState.Win,
                    OnCreated = new DateTime(2019, 8, 22, 12, 15, 00, 000, DateTimeKind.Local),
                    OnUpdated = DateTime.MinValue,
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674",
                    PlayerId = "c09c1133-242d-43f8-9ce6-afac824b88c0",
                    OrderId = "b3fb6608-5597-4cbf-8cd1-ba74399ee308"
                },
                new Game
                {
                    Id = "cf04144b-846b-450c-8d5e-35c11a64acd3",
                    Status = PlayStatus.Over,
                    State = PlayState.Lose,
                    OnCreated = new DateTime(2019, 8, 22, 12, 20, 00, 000, DateTimeKind.Local),
                    OnUpdated = DateTime.MinValue,
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9",
                    PlayerId = "c09c1133-242d-43f8-9ce6-afac824b88c0",
                    OrderId = "b3592c2e-6e78-4ebe-a494-ae00e5dbaeeb"
                },
                new Game
                {
                    Id = "91763ee1-382c-43b6-bcff-0c7146400544",
                    Status = PlayStatus.Over,
                    State = PlayState.Lose,
                    OnCreated = new DateTime(2019, 8, 22, 12, 25, 00, 000, DateTimeKind.Local),
                    OnUpdated = DateTime.MinValue,
                    CraneId = "42ba9d7d-62ba-4958-87a7-1bef9df38674",
                    PlayerId = "8558b62a-7e15-4083-b6d7-cd199839fd31",
                    OrderId = "516dab55-308c-4741-af35-7733c316dbd2"
                },
                new Game
                {
                    Id = "16259d75-2244-4bcc-b0e7-73a20d5d2243",
                    Status = PlayStatus.Over,
                    State = PlayState.Win,
                    OnCreated = new DateTime(2019, 8, 22, 12, 30, 00, 000, DateTimeKind.Local),
                    OnUpdated = DateTime.MinValue,
                    CraneId = "ce7ea78e-56d6-49db-bb84-4165e3c958e9",
                    PlayerId = "8558b62a-7e15-4083-b6d7-cd199839fd31",
                    OrderId = "58b773a5-2bb7-4106-a510-d4ab8ac0bbad"
                });

            builder.Entity<Play>().HasData(
                new Play
                {
                    Id = "aa7e7fa8-07df-4368-85b1-74f0dfde0ac0",
                    GameId = "322173e1-9821-4026-a0c2-cecd97ea3f64",
                    Status = PlayStatus.Ready,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 31, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "e835a48a-f0e9-4a83-96ae-886d7cb6fb48",
                    GameId = "322173e1-9821-4026-a0c2-cecd97ea3f64",
                    Status = PlayStatus.Playing,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 32, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "119355fd-dc13-45fe-a5bb-122f727c58b3",
                    GameId = "322173e1-9821-4026-a0c2-cecd97ea3f64",
                    Status = PlayStatus.Over,
                    State = PlayState.Win,
                    OnCreated = new DateTime(2019, 8, 22, 12, 33, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "f8449d35-6217-4c27-8eef-9dabda971081",
                    GameId = "cf04144b-846b-450c-8d5e-35c11a64acd3",
                    Status = PlayStatus.Ready,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 34, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "93e46c07-3261-466c-91de-4423166d9227",
                    GameId = "cf04144b-846b-450c-8d5e-35c11a64acd3",
                    Status = PlayStatus.Playing,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 35, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "2fc59b99-891d-4aa3-ada5-132414094e0d",
                    GameId = "cf04144b-846b-450c-8d5e-35c11a64acd3",
                    Status = PlayStatus.Over,
                    State = PlayState.Lose,
                    OnCreated = new DateTime(2019, 8, 22, 12, 36, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "0a4cc44f-d7e9-41df-9ae7-f2930afb3134",
                    GameId = "91763ee1-382c-43b6-bcff-0c7146400544",
                    Status = PlayStatus.Ready,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 37, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "b763531b-fb5e-4e87-9c78-c7b8f4fcad7e",
                    GameId = "91763ee1-382c-43b6-bcff-0c7146400544",
                    Status = PlayStatus.Playing,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 38, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "2b187756-fadb-4b2a-85d3-30c5219c78a5",
                    GameId = "91763ee1-382c-43b6-bcff-0c7146400544",
                    Status = PlayStatus.Over,
                    State = PlayState.Lose,
                    OnCreated = new DateTime(2019, 8, 22, 12, 39, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "c6d31ffa-8e26-41d9-8347-3322c1c4ca27",
                    GameId = "16259d75-2244-4bcc-b0e7-73a20d5d2243",
                    Status = PlayStatus.Ready,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 40, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "1f1e4209-d122-473d-adbf-ef4b70dc233a",
                    GameId = "16259d75-2244-4bcc-b0e7-73a20d5d2243",
                    Status = PlayStatus.Playing,
                    State = PlayState.Waiting,
                    OnCreated = new DateTime(2019, 8, 22, 12, 41, 00, 000, DateTimeKind.Local)
                },
                new Play
                {
                    Id = "d9b0e57a-40af-420f-8989-ebed4b8b8ec1",
                    GameId = "16259d75-2244-4bcc-b0e7-73a20d5d2243",
                    Status = PlayStatus.Over,
                    State = PlayState.Win,
                    OnCreated = new DateTime(2019, 8, 22, 12, 42, 00, 000, DateTimeKind.Local)
                });
        }
    }
}        
