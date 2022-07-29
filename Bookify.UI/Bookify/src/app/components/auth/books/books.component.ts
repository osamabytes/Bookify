import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Book } from 'src/app/models/Book.model';
import { BookService } from 'src/app/services/Book.Service/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})

export class BooksComponent implements AfterViewInit {
  booksTableColumn: string[] = ['name', 'isbn', 'active', 'actions'];

  dataSource: MatTableDataSource<Book>;

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;


  books: Book[] = [];

  constructor(private bookService: BookService) {
    this.books = this.bookService.AllBooks();
    this.dataSource = new MatTableDataSource(this.books);
  }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

}
