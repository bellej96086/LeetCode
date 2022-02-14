using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Problem_Database
    {
        // Topic: Database
        /// <summary>
        /// Problems 175. Combine Two Tables
        /// </summary>
        public static string Combine_Two_Tables(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"Select FirstName, LastName, City, State From Person p, Address a Where p.PersonId = a.PersonId(+)";
                    break;
                case "MYSQL":
                    return @"Select FirstName, LastName, City, State From Person left join Address on Address.PersonId = Person.PersonId";
                    break;
                case "MSSQL":
                    return @"Select FirstName, LastName, City, State From Person left join Address on Address.PersonId = Person.PersonId";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 176. Second Highest Salary
        /// </summary>
        public static string Second_Highest_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"Select case when count(Salary) < 2 then Max(Salary) else null end SecondHighestSalary 
From
    (Select rownum rn, Salary
    From
        (Select Salary
        From Employee
        Group by Salary
        Order by Salary desc))
Where rn = 2";
                    break;
                case "MYSQL":
                    return @"Select case when count(Salary) = 2 then Min(Salary) else null end SecondHighestSalary 
From
    (Select Salary
    From
        (Select Salary
        From Employee
        Group by Salary
        Order by Salary desc) e
    Limit 2) e";
                    break;
                case "MSSQL":
                    return @"Select case when count(Salary) = 2 then Min(Salary) else null end SecondHighestSalary 
From    
    (Select Top 2 Salary
    From Employee
    Group by Salary
    Order by Salary desc) Employee";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 177. Nth Highest Salary
        /// </summary>
        public static string Nth_Highest_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"CREATE FUNCTION getNthHighestSalary(N IN NUMBER) RETURN NUMBER IS
result NUMBER;
BEGIN
    /* Write your PL/SQL query statement below */
    Select case when count(Salary) = 1 then Min(Salary) else null end INTO result 
    From
        (Select rownum rn, Salary
        From
            (Select Salary
            From Employee
            Group by Salary
            Order by Salary desc))
    Where rn = N;

    RETURN result;
END;";
                    break;
                case "MYSQL":
                    return @"CREATE FUNCTION getNthHighestSalary(N INT) RETURNS INT
BEGIN
  RETURN (
      # Write your MySQL query statement below.
      Select case when count(Salary) = N then Min(Salary) else null end SecondHighestSalary 
      From
        (Select Salary
        From
            (Select Salary
            From Employee
            Group by Salary
            Order by Salary desc) e
        Limit N) e    
  );
END";
                    break;
                case "MSSQL":
                    return @"CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    RETURN (
        /* Write your T-SQL query statement below. */
        Select case when count(Salary) = @N then Min(Salary) else null end SecondHighestSalary 
        From    
            (Select Top (@N) Salary
            From Employee
            Group by Salary
            Order by Salary desc) Employee
    );
END";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 178. Rank Scores
        /// </summary>
        public static string Rank_Scores(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select A.score, B.rk as Rank
from Scores A
    , (select score, rownum rk 
        from (SELECT score 
              FROM Scores 
              GROUP BY score
              ORDER BY Score DESC)) B
where A.score = B.score(+)
ORDER BY Score DESC";
                    break;
                case "MYSQL":
                    return @"select A.score, B.rk `Rank`
from Scores A
    left join (select score, ROW_NUMBER() OVER(ORDER BY Score desc) rk 
                from (SELECT score 
                      FROM Scores 
                      GROUP BY score
                      ORDER BY Score DESC) B) B on A.score = B.score
ORDER BY Score DESC";
                    break;
                case "MSSQL":
                    return @"select top 10000 A.score, B.rk as Rank
from Scores A
    left join (select top 10000 score, ROW_NUMBER() OVER(ORDER BY Score desc) rk 
                from (SELECT top 10000 score 
                      FROM Scores 
                      GROUP BY score
                      ORDER BY Score DESC) B) B on A.score = B.score
ORDER BY Score DESC";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 180. Consecutive Numbers
        /// </summary>
        public static string Consecutive_Numbers(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select distinct num ConsecutiveNums 
                    from
                        (select logs.*
                            , case when num != nvl(lead(num) over (order by id asc), num - 1) then 0 else 1 end as next
                            , case when num != nvl(lag(num) over (order by id asc), num - 1) then 0 else 1 end as back 
                        from Logs
                        order by id asc) logs
                    where next = 1 and back = 1";
                    break;
                case "MYSQL":
                    return @"select distinct num ConsecutiveNums 
from
    (select logs.*
        , case when num != IFNULL(lead(num) over (order by id asc), num - 1) then 0 else 1 end as next
        , case when num != IFNULL(lag(num) over (order by id asc), num - 1) then 0 else 1 end as back 
    from Logs
    order by id asc) logs
where next = 1 and back = 1";
                    break;
                case "MSSQL":
                    return @"select distinct num ConsecutiveNums 
from
    (select top 10000 logs.*
        , case when num != ISNULL(lead(num) over (order by id asc), num - 1) then 0 else 1 end as next
        , case when num != ISNULL(lag(num) over (order by id asc), num - 1) then 0 else 1 end as back 
    from Logs
    order by id asc) logs
where next = 1 and back = 1";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 181. Employees Earning More Than Their Managers
        /// </summary>
        public static string Employees_Earning_More_Than_Their_Managers(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select name Employee
from Employee e
where managerid is not null 
    and salary > (select salary from employee m where m.id = e.managerid)";
                    break;
                case "MYSQL":
                    return @"select name Employee
from Employee e
where managerid is not null 
    and salary > (select salary from employee m where m.id = e.managerid)";
                    break;
                case "MSSQL":
                    return @"select name Employee
from Employee e
where managerid is not null 
    and salary > (select salary from employee m where m.id = e.managerid)";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 182. Duplicate Emails
        /// </summary>
        public static string Duplicate_Emails(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select Email
from Person
group by email
having count(email) > 1";
                    break;
                case "MYSQL":
                    return @"select Email
from Person
group by email
having count(email) > 1";
                    break;
                case "MSSQL":
                    return @"select Email
from Person
group by email
having count(email) > 1";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 183. Customers Who Never Order
        /// </summary>
        public static string Customers_Who_Never_Order(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select name as Customers
from customers c
    , orders o
where c.id = o.customerid(+)
    and o.id is null";
                    break;
                case "MYSQL":
                    return @"select name as Customers
from customers c
    left join orders o on c.id = o.customerid
where o.id is null";
                    break;
                case "MSSQL":
                    return @"select name as Customers
from customers c
    left join orders o on c.id = o.customerid
where o.id is null";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 184. Department Highest Salary
        /// </summary>
        public static string Department_Highest_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
    , Department d
    , (select d.id, max(e.salary) salary
        from Employee e, Department d
        where e.departmentid = d.id(+)
        group by d.id) hs
where e.departmentid = d.id(+)
    and e.salary = hs.salary
    and d.id = hs.id";
                    break;
                case "MYSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select d.id, max(e.salary) salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary and d.id = hs.id";
                    break;
                case "MSSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select d.id, max(e.salary) salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary and d.id = hs.id";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 185. Department Top Three Salaries
        /// </summary>
        public static string Department_Top_Three_Salaries(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
    , Department d
    , (select rank() over(partition by d.id order by e.Salary desc) rank3, d.id, e.salary
        from Employee e, Department d
        where e.departmentid = d.id(+) 
        group by d.id, e.salary) hs
where e.departmentid = d.id(+)
    and e.salary = hs.salary
    and d.id = hs.id
    and hs.rank3 <= 3";
                case "MYSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select rank() over(partition by d.id order by e.Salary desc) rank3, d.id, e.salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id, e.salary) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary 
    and d.id = hs.id
    and hs.rank3 <= 3";
                case "MSSQL":
                    return @"select d.name as Department
    , e.name Employee
    , e.Salary
from Employee e
	right join Department d on e.departmentid = d.id
	right join (select rank() over(partition by d.id order by e.Salary desc) rank3, d.id, e.salary
                from Employee e
                    right join Department d on e.departmentid = d.id
                group by d.id, e.salary) hs on e.salary = hs.salary and d.id = hs.id
where e.salary = hs.salary 
    and d.id = hs.id
    and hs.rank3 <= 3";
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 196. Delete Duplicate Emails
        /// </summary>
        public static string Delete_Duplicate_Emails(string Language)
        {
            switch (Language)
            {
                case "MYSQL":
                    return @"delete from person
where id in (select p.id
             from (select id, rank() over(partition by email order by id asc) rank2
                   from person) p
             where p.rank2 >= 2)";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 197. Rising Temperature
        /// </summary>
        public static string Rising_Temperature(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select id
from (select id, recordDate, temperature, nvl(lag(temperature) over (order by recordDate asc), 105) ex_temperature
      from weather
      order by recordDate asc) w
where temperature > ex_temperature 
    and recordDate - 1 in (select recordDate from weather)";
                    break;
                case "MYSQL":
                    return @"select id
from (select id, recordDate, temperature, ifnull(lag(temperature) over (order by recordDate asc), 105) ex_temperature
      from weather
      order by recordDate asc) w
where temperature > ex_temperature 
    and date_sub(recordDate, interval 1 day) in (select recordDate from weather)";
                    break;
                case "MSSQL":
                    return @"select id
from (select top 10000 id, recordDate, temperature, isnull(lag(temperature) over (order by recordDate asc), 105) ex_temperature
      from weather
      order by recordDate asc) w
where temperature > ex_temperature 
    and dateadd(day, -1, recordDate) in (select recordDate from weather)";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 262. Trips and Users
        /// </summary>
        public static string Trips_and_Users(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select request_at as ""DAY""
    , round(sum(case status when 'completed' then 0 else 1 end) / count(status), 2) as ""Cancellation Rate""
from trips t
    , users c
    , users d
where t.client_id = c.users_id(+)
    and t.driver_id = d.users_id(+)
    and c.banned = 'No'
    and d.banned = 'No'
    and to_date(request_at, 'yyyy-mm-dd') between TO_DATE('2013-10-01', 'yyyy-mm-dd') and TO_DATE('2013-10-03', 'yyyy-mm-dd')
group by request_at
order by request_at asc";
                    break;
                case "MYSQL":
                    return @"select request_at as ""DAY""
    , round(sum(case status when 'completed' then 0 else 1 end) / count(status), 2) as ""Cancellation Rate""
from trips t
    right
join users c on t.client_id = c.users_id

right
join users d on t.driver_id = d.users_id
where c.banned = 'No'
    and d.banned = 'No'
    and DATE_FORMAT(request_at, '%Y-%m-%d') between DATE_FORMAT('2013-10-01', '%Y-%m-%d') and DATE_FORMAT('2013-10-03', '%Y-%m-%d')
group by request_at
order by request_at asc";
                    break;
                case "MSSQL":
                    return @"select request_at as ""DAY""
    , round(sum(case status when 'completed' then 0.0 else 1.0 end) / count(*), 2) as ""Cancellation Rate""
from trips t
    right
join users c on t.client_id = c.users_id

right
join users d on t.driver_id = d.users_id
where c.banned = 'No'
    and d.banned = 'No'
    and CONVERT(DATETIME, request_at) between CONVERT(DATETIME, '2013-10-01') and CONVERT(DATETIME, '2013-10-03')
group by request_at
order by request_at asc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 595. Big Countries
        /// </summary>
        public static string Big_Countries(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select name, population, area
from world
where population >= 25000000 
    or area >= 3000000";
                    break;
                case "MYSQL":
                    return @"select name, population, area
from world
where population >= 25000000 
    or area >= 3000000";
                    break;
                case "MSSQL":
                    return @"select name, population, area
from world
where population >= 25000000 
    or area >= 3000000";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 596. Classes More Than 5 Students
        /// </summary>
        public static string Classes_More_Than_5_Students(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select class
from courses
group by class
having count(distinct student) >= 5";
                case "MYSQL":
                    return @"select class
from courses
group by class
having count(distinct student) >= 5";
                case "MSSQL":
                    return @"select class
from courses
group by class
having count(distinct student) >= 5";
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 601. Human Traffic of Stadium
        /// </summary>
        public static string Human_Traffic_of_Stadium(string Language)
        {
            switch (Language)
            {
                case "PLSQL"://不能submit
                    return @"/* Write your PL/SQL query statement below */
select id
    , visit_date
    , people
from (select s.*
        , lag(people) over(order by id asc) lag_people
        , lag(people, 2) over(order by id asc) lag2_people
        , lead(people) over(order by id asc) lead_people
        , lead(people, 2) over(order by id asc) lead2_people
    from Stadium s) s
where s.people >= 100
    AND ((lag_people >= 100 AND lag2_people >= 100)
    OR (lag_people >= 100 AND lead_people >= 100)
    OR (lead_people >= 100 AND lead2_people >= 100))
order by id asc";
                    break;
                case "MYSQL":
                    return @"/* Write your PL/SQL query statement below */
select id
    , visit_date
    , people
from (select s.*
        , lag(people) over(order by id asc) lag_people
        , lag(people, 2) over(order by id asc) lag2_people
        , lead(people) over(order by id asc) lead_people
        , lead(people, 2) over(order by id asc) lead2_people
    from Stadium s) s
where s.people >= 100
    AND ((lag_people >= 100 AND lag2_people >= 100)
    OR (lag_people >= 100 AND lead_people >= 100)
    OR (lead_people >= 100 AND lead2_people >= 100))
order by id asc";
                    break;
                case "MSSQL":
                    return @"/* Write your PL/SQL query statement below */
select id
    , visit_date
    , people
from (select s.*
        , lag(people) over(order by id asc) lag_people
        , lag(people, 2) over(order by id asc) lag2_people
        , lead(people) over(order by id asc) lead_people
        , lead(people, 2) over(order by id asc) lead2_people
    from Stadium s) s
where s.people >= 100
    AND ((lag_people >= 100 AND lag2_people >= 100)
    OR (lag_people >= 100 AND lead_people >= 100)
    OR (lead_people >= 100 AND lead2_people >= 100))
order by id asc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 620. Not Boring Movies
        /// </summary>
        public static string Not_Boring_Movies(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select *
from Cinema
where description != 'boring'
    and mod(id, 2) = 1
order by rating desc";
                    break;
                case "MYSQL":
                    return @"select *
from Cinema
where description != 'boring'
    and mod(id, 2) = 1
order by rating desc";
                    break;
                case "MSSQL":
                    return @"select *
from Cinema
where description != 'boring'
    and id % 2 = 1
order by rating desc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 626. Exchange Seats
        /// </summary>
        public static string Exchange_Seats(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select case when s.after_id > m.id then s.id else s.after_id end id
    , s.student
from (select s.*
        , case when mod(id, 2) = 0 then id - 1 else id + 1 end after_id
    from seat s) s
    , (select max(id) id from seat) m
order by s.after_id asc";
                    break;
                case "MYSQL":
                    return @"select case when s.after_id > m.id then s.id else s.after_id end id
    , s.student
from (select s.*
        , case when mod(id, 2) = 0 then id - 1 else id + 1 end after_id
    from seat s) s
    , (select max(id) id from seat) m
order by s.after_id asc";
                    break;
                case "MSSQL":
                    return @"select case when s.after_id > m.id then s.id else s.after_id end id
    , s.student
from (select s.*
        , case when id % 2 = 0 then id - 1 else id + 1 end after_id
    from seat s) s
    , (select max(id) id from seat) m
order by s.after_id asc";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 627. Swap Salary
        /// </summary>
        public static string Swap_Salary(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"update salary
set sex = decode(sex, 'm', 'f'
                    , 'f', 'm')";
                    break;
                case "MYSQL":
                    return @"update salary
set sex = case sex when 'm' then 'f' when 'f' then 'm' end";
                    break;
                case "MSSQL":
                    return @"update salary
set sex = case sex when 'm' then 'f' when 'f' then 'm' end";
                    break;
            }
            return "Fault Language";
        }
        /// <summary>
        /// Problems 1179. Reformat Department Table
        /// </summary>
        public static string Reformat_Department_Table(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"select id
    , sum(case month when 'Jan' then revenue end) Jan_Revenue
    , sum(case month when 'Feb' then revenue end) Feb_Revenue
    , sum(case month when 'Mar' then revenue end) Mar_Revenue
    , sum(case when month = 'Apr' then revenue end) Apr_Revenue
    , sum(case when month = 'May' then revenue end) May_Revenue
    , sum(case when month = 'Jun' then revenue end) Jun_Revenue
    , sum(case when month = 'Jul' then revenue end) Jul_Revenue
    , sum(case when month = 'Aug' then revenue end) Aug_Revenue
    , sum(case when month = 'Sep' then revenue end) Sep_Revenue
    , sum(case when month = 'Oct' then revenue end) Oct_Revenue
    , sum(case when month = 'Nov' then revenue end) Nov_Revenue
    , sum(case when month = 'Dec' then revenue end) Dec_Revenue
from department
group by id";
                    break;
                case "MYSQL":
                    return @"select id
    , sum(case month when 'Jan' then revenue end) Jan_Revenue
    , sum(case month when 'Feb' then revenue end) Feb_Revenue
    , sum(case month when 'Mar' then revenue end) Mar_Revenue
    , sum(case when month = 'Apr' then revenue end) Apr_Revenue
    , sum(case when month = 'May' then revenue end) May_Revenue
    , sum(case when month = 'Jun' then revenue end) Jun_Revenue
    , sum(case when month = 'Jul' then revenue end) Jul_Revenue
    , sum(case when month = 'Aug' then revenue end) Aug_Revenue
    , sum(case when month = 'Sep' then revenue end) Sep_Revenue
    , sum(case when month = 'Oct' then revenue end) Oct_Revenue
    , sum(case when month = 'Nov' then revenue end) Nov_Revenue
    , sum(case when month = 'Dec' then revenue end) Dec_Revenue
from department
group by id";
                    break;
                case "MSSQL":
                    return @"select id
    , sum(case month when 'Jan' then revenue end) Jan_Revenue
    , sum(case month when 'Feb' then revenue end) Feb_Revenue
    , sum(case month when 'Mar' then revenue end) Mar_Revenue
    , sum(case when month = 'Apr' then revenue end) Apr_Revenue
    , sum(case when month = 'May' then revenue end) May_Revenue
    , sum(case when month = 'Jun' then revenue end) Jun_Revenue
    , sum(case when month = 'Jul' then revenue end) Jul_Revenue
    , sum(case when month = 'Aug' then revenue end) Aug_Revenue
    , sum(case when month = 'Sep' then revenue end) Sep_Revenue
    , sum(case when month = 'Oct' then revenue end) Oct_Revenue
    , sum(case when month = 'Nov' then revenue end) Nov_Revenue
    , sum(case when month = 'Dec' then revenue end) Dec_Revenue
from department
group by id";
                    break;
            }
            return "Fault Language";
        }

        /// <summary>
        /// Problems 
        /// </summary>
        public static string A(string Language)
        {
            switch (Language)
            {
                case "PLSQL":
                    return @"";
                    break;
                case "MYSQL":
                    return @"";
                    break;
                case "MSSQL":
                    return @"";
                    break;
            }
            return "Fault Language";
        }
    }
}
