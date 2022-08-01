import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Author } from 'src/app/models/Author.model';
import { AuthorService } from 'src/app/services/Author.Service/author.service';
import { ViewAuthorModalComponent } from '../../Modals/view-author-modal/view-author-modal.component';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css']
})
export class AuthorsComponent implements AfterViewInit {
  authorTableColumn: string[] = ['name', 'description', 'actions'];

  dataSource: MatTableDataSource<Author> = new MatTableDataSource;

  authors: Author[] = [];

  constructor(private dialog: MatDialog, private authorService: AuthorService) {
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;
  
  ngAfterViewInit(): void {
    this.authorService.AllAuthors()
    .subscribe({
      next: (authors) => {
        this.authors = authors;
        this.dataSource = new MatTableDataSource<Author>(this.authors);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  applyFilter(event: Event){
    var filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  openViewDialog(id: string){

    this.authorService.GetAuthor(id)
    .subscribe({
      next: (author) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = author;

        this.dialog.open(ViewAuthorModalComponent, dialogConfig);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  DeleteAuthor(id: string){
    this.authorService.Delete(id)
    .subscribe({
      next: (response: any) => {
        console.log("Author Deleted Successfully");

        for(var i=0; i < this.authors.length; i++){
          let authorObj = this.authors[i];

          if(authorObj.id === id){
            this.authors.splice(i, 1);
          }

          this.dataSource.data = this.authors;
        }
      },
      error: (err) => {
        if(err.status == 400){
          console.log("Server Error");
        }
      }
    })
  }

}
