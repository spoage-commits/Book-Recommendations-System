using System;
using System.Collections.Generic;

class Program
{
    // Services and repositories
    private static AuthenticationService authService;
    private static RatingService ratingService;
    private static RecommendationService recommendationService;
    private static BookRepository bookRepo;
    private static MemberRepository memberRepo;
    
    // Load data files
    var loader = new DataLoader(bookRepo, memberRepo, ratingService);
    loader.LoadBooks("books.txt");
    loader.LoadRatings("ratings.txt");

    Console.WriteLine("Data loaded successfully! Press Enter to continue.");
    Console.ReadLine();

    static void Main(string[] args)
    {
        // Initialize repositories
        bookRepo = new BookRepository();
        memberRepo = new MemberRepository();

        // Initialize services
        authService = new AuthenticationService(memberRepo);
        ratingService = new RatingService(memberRepo, bookRepo);
        recommendationService = new RecommendationService(memberRepo, bookRepo, new DotProductStrategy());

        // Main loop
        while (true)
        {
            Console.Clear();
            if (!authService.IsLoggedIn)
            {
                ShowLoggedOutMenu();
            }
            else
            {
                ShowLoggedInMenu();
            }
        }
    }

    static void ShowLoggedOutMenu()
    {
        Console.WriteLine("===== Book Recommendation System =====");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Add Member");
        Console.WriteLine("3. Exit");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                HandleLogin();
                break;
            case "2":
                HandleAddMember();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Press Enter to continue.");
                Console.ReadLine();
                break;
        }
    }

    static void ShowLoggedInMenu()
    {
        Console.WriteLine($"===== Welcome, {authService.GetCurrentMember().Name} =====");
        Console.WriteLine("1. View Ratings");
        Console.WriteLine("2. Rate Book");
        Console.WriteLine("3. Get Recommendations");
        Console.WriteLine("4. Add Book");
        Console.WriteLine("5. Logout");
        Console.Write("Select an option: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                HandleViewRatings();
                break;
            case "2":
                HandleRateBook();
                break;
            case "3":
                HandleGetRecommendations();
                break;
            case "4":
                HandleAddBook();
                break;
            case "5":
                authService.Logout();
                Console.WriteLine("Logged out successfully. Press Enter to continue.");
                Console.ReadLine();
                break;
            default:
                Console.WriteLine("Invalid option. Press Enter to continue.");
                Console.ReadLine();
                break;
        }
    }

    // ======== HANDLERS ========

    static void HandleLogin()
    {
        Console.Write("Enter Account ID: ");
        string accountId = Console.ReadLine();

        if (authService.Login(accountId))
        {
            Console.WriteLine($"Logged in successfully as {authService.GetCurrentMember().Name}");
        }
        else
        {
            Console.WriteLine("Login failed. Account ID not found.");
        }
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void HandleAddMember()
    {
        Console.Write("Enter member name: ");
        string name = Console.ReadLine();
        string accountId = Guid.NewGuid().ToString();

        Member newMember = new Member(accountId, name);
        memberRepo.Add(newMember);

        Console.WriteLine($"Member created with ID: {accountId}");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void HandleAddBook()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        Console.Write("Enter author: ");
        string author = Console.ReadLine();
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());
        string isbn = Guid.NewGuid().ToString();

        Book newBook = new Book(isbn, title, author, year);
        bookRepo.Add(newBook);

        Console.WriteLine($"Book added: {title}");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void HandleViewRatings()
    {
        var member = authService.GetCurrentMember();
        var ratings = ratingService.GetRatingsForMember(member);

        Console.WriteLine("Your Ratings:");
        foreach (var rating in ratings)
        {
            Console.WriteLine(rating.ToString());
        }

        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void HandleRateBook()
    {
        var member = authService.GetCurrentMember();
        var books = bookRepo.GetAll();

        Console.WriteLine("Select a book to rate:");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {books[i].Title} by {books[i].Author}");
        }

        Console.Write("Enter book number: ");
        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice < 0 || choice >= books.Count)
        {
            Console.WriteLine("Invalid selection. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        Book selectedBook = books[choice];

        Console.WriteLine("Enter rating: -5, -3, 0, 1, 3, 5");
        int value = int.Parse(Console.ReadLine());
        RatingValue ratingValue = (RatingValue)value;

        ratingService.AddRating(member, selectedBook, ratingValue);

        Console.WriteLine($"You rated '{selectedBook.Title}' as {ratingValue}");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }

    static void HandleGetRecommendations()
    {
        static void HandleGetRecommendations()
        {
            var member = authService.GetCurrentMember();

            Console.Write("How many recommendations would you like to see? ");
            int topN = int.Parse(Console.ReadLine());

            var recommendations = recommendationService.GetRecommendations(member, topN);

            Console.WriteLine("Recommended Books:");
            foreach (var book in recommendations)
            {
                Console.WriteLine($"{book.Title} by {book.Author} ({book.Year})");
            }

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}