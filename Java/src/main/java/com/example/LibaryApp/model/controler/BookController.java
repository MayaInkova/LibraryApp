package com.example.LibaryApp.model.controler;
import  com.example.LibaryApp.model.Book;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/books")
public class BookController {

    private List<Book> books = new ArrayList<>();

    public BookController () {

        books.add(new Book(1,"The Great","Nikolos"));
        books.add(new Book(2,"To Kill","Layra"));
        books.add(new Book(3,"19984","George"));

        //Заявки


    }
@GetMapping
    public  List<Book>getBooks() {
        return books;
    }
    @PostMapping
    public  Book addBook( @RequestBody Book book) {
        books.add(book);
        return book;
    }


}
