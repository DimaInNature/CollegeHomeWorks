using System;
using System.Collections.Generic;
using System.Linq;
using Work2.Enums;
using Work2.Models;

namespace Work2.Services
{
    public static class TaskManager
    {
        /// <summary>
        /// The initial sequence contains information about the clients of the fitness center.
        /// Each element of the sequence includes the following integer fields:
        /// Client Code, Year, Month Number, Duration of classes(in hours) 
        /// Determine the year in which the total duration of classes of all clients was
        /// the largest, and output this year and the largest total duration. If
        /// there were several such years, then output the smallest of them.
        /// </summary>
        public static void TaskOne(List<ClientModel> clients)
        {
            Console.WriteLine("Task One");

            var result =
                clients.GroupBy(y => y.Year)
                .Select(i => new
                {
                    Year = i.Key,
                    Hours = i.Select(x => x.DurationOfActivitiesInHours).Sum()
                })
                .OrderByDescending(sum => sum.Hours)
                .ThenBy(y => y.Year)
                .FirstOrDefault();

            Console.WriteLine($"{result.Year}: {result.Hours}");
        }

        /// <summary>
        /// The initial sequence contains information about the clients of
        /// the fitness center.Each element of the sequence includes the following integer fields:
        /// Client Code, Year, Month Number, Duration of classes(in hours), 
        /// Foreach client present in the source data, determine the total number of
        /// months during which he attended classes(first output the number of months,
        /// then the client code). Information about each client should be displayed on a new line and
        /// ordered in ascending order of the number of months, and if they are equal,
        /// in ascending order client code.
        /// </summary>
        public static void TaskTwo(List<ClientModel> clients)
        {
            Console.WriteLine("Task Two");

            var result = clients.Select(client => new ClientModel() 
               {
                   NumberMonth = client.NumberMonth, 
                   Id = client.Id
               })
               .OrderBy(s => s.NumberMonth)
               .ThenByDescending(s => s.Id)
               .ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.NumberMonth}: {item.Id}");
            }
        }
        
        /// <summary>
        /// The initial sequence contains information about applicants.Each
        /// the sequence element includes the following fields:
        /// Last name, School Number, Year of admission
        /// For each school, find the years of admission of applicants from
        /// this school and output the number schools and the years found for
        /// it(the years are located on the same line as the number
        /// schools, and are ordered in ascending order). Information about each school
        /// should be displayed on a new line and arranged in ascending order of school
        /// numbers.If the year repeats, then output only once.
        /// </summary>
        public static void TaskThree(List<EnrolleeModel> enrolees)
        {
            Console.WriteLine("Task Three");

            var result = enrolees.GroupBy(a => a.SchoolNumber).
                 Select(i => new
                 {
                     School = i.Key,
                     Years = i.Select(y => y.YearOfIntering)
                     .OrderBy(x => x)
                     .Distinct()
                 });

            foreach (var item in result)
            {
                Console.Write($"{item.School}: ");

                foreach (var year in item.Years)
                {
                    Console.Write($"{year} ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// From the sequence (see item 3), determine in which years the total number of
        /// the number of applicants for all schools was the largest and the smallest,
        /// and output this number, as well as the years in which it was achieved
        /// (arrange the years in ascending order, each print the number on a new line).
        /// </summary>
        public static void TaskFour(List<EnrolleeModel> enrollees)
        {
            Console.WriteLine("Task Four");

            var result = enrollees
                .GroupBy(a => a.YearOfIntering).
                Select(i => new
                {
                    Count = i.Select(p => p.Surname)
                    .Count(),
                    Year = i.Key
                });

            int max = result.Max(enr => enr.Count);
            int min = result.Min(enr => enr.Count);
            var resMax = result.Where(x => x.Count == max);
            var resMin = result.Where(x => x.Count == min);

            Console.WriteLine($"Years with the maximum number of enrollees({max})");

            foreach (var item in resMax)
            {
                Console.Write($"{item.Year} ");
            }

            Console.WriteLine("\n");

            Console.WriteLine($"Years with the minimum number of enrollees({min})");

            foreach (var item in resMin)
            {
                Console.Write($"{item.Year} ");
            }
        }
        /// <summary>
        /// Given an integer M - the value of one of the gasoline brands.Original
        /// the sequence contains information about gas stations (gas stations).Each
        /// the sequence element includes the following fields:
        /// Street, ,Company, Brand of gasoline, Price of 1 liter (with kopecks). The
        /// names of companies and streets do not contain spaces.The following are indicated
        /// as the brand of gasoline numbers 92, 95 or 98 Each company has no more than
        /// one gas station on each street; prices they may differ at different gas stations of
        /// the same company.For each street determine the number of gas stations that offered
        /// the brand of gasoline M (first output the number of gas stations on this street, then
        /// the name of the street, in the column display the names companies arranged
        /// in alphabetical order).Information about each street should be displayed on a
        /// new line and ordered in ascending order by the number of gas stations, and for
        /// the same quantities — by street names in alphabetical order.
        /// </summary>
        public static void TaskFive(List<GasStationModel> gasStations)
        {
            Console.WriteLine("Task Five");

            int gasolineBrand = new Random()
                .Next(0, Enum.GetNames(typeof(EGasoline)).Length);

            Console.WriteLine($"Gasoline brand is {(EGasoline)gasolineBrand}");

            var result = gasStations
                .Where(g => ((int)g.GasolineBrand) == gasolineBrand)
                .GroupBy(s => s.StreetName).
                Select(r =>
                new
                {
                    Street = r.Key,
                    Company = r
                    .Select(c => c.CompanyName)
                    .OrderBy(x => x),
                    Count = r.Count()
                })
                .OrderBy(c => c.Count)
                .ThenBy(t => t.Street);

            foreach (var item in result)
            {
                Console.WriteLine($"Street {item.Street} (station count: {item.Count}):");

                foreach (var str in item.Company)
                {
                    Console.WriteLine(str);
                }
                Console.WriteLine("\n");
            }
        }
        /// <summary>
        /// Sequences A and C are given, including the following fields:
        /// Consumer code, Year of birth, Street of residence,
        /// ,Consumer Code, ,Discount(as a percentage),Store Name
        /// For each store, determine the consumers who have the maximum discount in this
        /// store(first the name of the store is displayed, then the code of the consumer,
        /// his year of birth and the value of the maximum discount).If there are several for
        /// some store consumers with the maximum discount, then output data about the consumer
        /// with the minimum code.Information about each store should be displayed on a new line
        /// and sorted by store names in alphabetical order.
        /// </summary>
        public static void TaskSix(List<ConsumerModel> consumers, List<ShopModel> shops)
        {
            Console.WriteLine("Task Six");

            var result = consumers.Join(shops,
                consumerModel => consumerModel.Id, shopModel => shopModel.Id,
                (c, s) => new
                {
                    Shop = s.Name,
                    ConsumerId = s.Id,
                    ConsumerYearOfBirth = c.YearOfBirth,
                    Discount = s.DiscountInPercentage
                })
                .GroupBy(gr => gr.Shop)
                .Select(w => new
                {
                    shop = w.Key,
                    Consumer = w.Select(q =>
                    new {
                        year = q.ConsumerYearOfBirth,
                        consumerId = q.ConsumerId,
                        discount = q.Discount })
                    .OrderByDescending(o => o.discount)
                    .First()
                })
                .OrderBy(t => t.shop);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.shop} {item.Consumer.consumerId}" +
                    $" {item.Consumer.year} {item.Consumer.discount}");
            }
        }
        /// <summary>
        /// From the sequence (see paragraph 5) for each consumer specified in A,
        /// determine the number of stores in which he is given a discount(at the beginning
        /// the number of stores is displayed, then the consumer's code, then his
        /// street of residence). If some consumer does not have a discount in any store,
        /// then it is displayed for him the number of stores equal to 0 Information about
        /// each consumer should be displayed on the new row and arrange in ascending
        /// order the number of stores, and with an equal number - ascending codes of consumers.
        /// </summary>
        public static void TaskSeven(List<ConsumerModel> consumers, List<ShopModel> shops)
        {
            Console.WriteLine("Task Seven");

            var result = consumers.Join(shops,
                a => a.Id, c => c.Id,(a, c) => new
                {
                    Count = shops
                        .Count(id => id.Id == a.Id),
                    a.Id,
                    a.StreetName
                })
                .Distinct();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Count} {item.Id} {item.StreetName}");
            }
        }

        /// <summary>
        /// Two classes are given Student and Subject. The Student class contains
        /// information about grades students in school subjects.Each element of the
        /// sequence contains data about one assessment and includes the following fields:
        /// Full name, Class, Subject Code, Grade
        /// The Subject class contains a list of subjects that includes the following fields:
        /// Item Code, Item name
        /// The class is given as an integer, the score is an integer in
        /// the range 2 - 5.For each class
        /// determine the average score for each subject.The received information should be
        /// displayed on a separate line, indicating the class, the name of the subject and
        /// the average score.Data arrange the class numbers in ascending order and the average
        /// score in descending order.
        /// </summary>
        public static void TaskEight(List<StudentModel> students, List<SubjectModel> subjects)
        {
            Console.WriteLine("Task Eight");

            var result = students.Join(subjects, a => a.Id,
                b => b.Id,(a, b) => new
                {
                    a.Grade,
                    a.Group,Subject = b.Name})
                .GroupBy(s => s.Subject)
                .Select(r => new
                {
                    Subject = r.Key,
                    Average = r.GroupBy(c => c.Group)
                    .Select(x => new
                    {
                        Grade = x.Average(grade => (int)grade.Grade),
                        Group = x.Key
                    })
                    .OrderBy(s => s.Group)
                    .OrderByDescending(a => a.Grade),
                });

            foreach (var item in result)
            {
                foreach (var mid in item.Average)
                {
                    Console.WriteLine($"{item.Subject} {mid.Group} {mid.Grade}");
                }
            }
        }

        /// <summary>
        /// From the sequence (see p.6) for each student, determine the average
        /// assessment for each subject.Output the received information on a separate line,
        /// indicating the full name, the name of the subject and the average score.
        /// Arrange the data in alphabetical order in the order of surnames and in descending
        /// order of the average score.
        /// </summary>
        public static void TaskNine(List<StudentModel> students, List<SubjectModel> subjects)
        {
            Console.WriteLine("Task Nine");

            var result = students
                .Join(subjects,  studentModel => studentModel.SubjectId,
                    subjectModel => subjectModel.Id,
                (studentModel, subjectModel) => new
                {
                    studentModel.FullName,
                    Subject = subjectModel.Name,
                    studentModel.Grade
                })
                .GroupBy(x => x.FullName)
                .Select(selector => new
                {
                    FullName = selector.Key,
                    Average = selector
                    .GroupBy(x => x.Subject)
                    .Select(s => new
                    {
                        Grade = s.Average(a => (int)a.Grade),
                        Subject = s.Key
                    })
                    .OrderByDescending(r => r.Grade)})
                .OrderBy(f => f.FullName);

            foreach (var item in result)
            {
                foreach (var mid in item.Average)
                {
                    Console.WriteLine($"{item.FullName} {mid.Subject} {mid.Grade}");
                }
            }
        }
    }
}
