import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Book } from 'src/app/models/Book.model';
import { BookService } from 'src/app/services/Book.Service/book.service';

export interface UserData {
  id: string;
  name: string;
  progress: string;
  fruit: string;
}

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})

export class BooksComponent implements AfterViewInit {
  booksTableColumn: string[] = ['id', 'name', 'progress', 'fruit'];

  dataSource: MatTableDataSource<UserData>;

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;


  books: Book[] = [];

  constructor(private bookService: BookService) {
    // this.booksTableColumn = this.bookService.GetBookColumn();
    // this.books = this.bookService.AllBooks();

    const users = this.createNewUser();
    this.dataSource = new MatTableDataSource(users);
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

  createNewUser(): UserData[]{
    return [{
      id: '123',
      name: 'Osama',
      progress: '85%',
      fruit: 'Mango'
    },{
      id: '123',
      name: 'Osama',
      progress: '85%',
      fruit: 'Mango'
    },{
      id: '123',
      name: 'Osama',
      progress: '85%',
      fruit: 'Mango'
    }]
  }

}
