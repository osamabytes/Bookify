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

  dataSource: MatTableDataSource<Author>;

  authors: Author[] = [];

  constructor(private dialog: MatDialog, private authorService: AuthorService) { 
    this.authors = this.authorService.AllAuthors();
    this.dataSource = new MatTableDataSource<Author>(this.authors);
  }

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;
  
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;    
  }

  applyFilter(event: Event){
    var filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  openViewDialog(id: string){
    let author: Author = this.authorService.GetAuthor(id);

    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = author;

    this.dialog.open(ViewAuthorModalComponent, dialogConfig);
  }

}
