import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Bookshop } from 'src/app/models/Bookshop.model';
import { BookshopService } from 'src/app/services/BookShop.Service/bookshop.service';
import { ViewBookshopModalComponent } from '../../Modals/view-bookshop-modal/view-bookshop-modal.component';

@Component({
  selector: 'app-bookshops',
  templateUrl: './bookshops.component.html',
  styleUrls: ['./bookshops.component.css']
})
export class BookshopsComponent implements AfterViewInit {
  bookShopTableColumn: string[] = ['name', 'address', 'actions'];

  dataSource: MatTableDataSource<Bookshop> = new MatTableDataSource;

  @ViewChild(MatPaginator) paginator : MatPaginator | any;
  @ViewChild(MatSort) sort : MatSort | any;

  bookShops: Bookshop[] = [];

  constructor(private dialog: MatDialog, private bookShopService: BookshopService) {}
  
  ngAfterViewInit(): void {
    this.bookShopService.AllBookshops()
    .subscribe({
      next: (bookShops) => {
        this.bookShops = bookShops;
        this.dataSource = new MatTableDataSource<Bookshop>(this.bookShops);

        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  applyFilter(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  openViewDialog(id: string){
    this.bookShopService.GetBookShop(id)
    .subscribe({
      next: (bookShop) => {
        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = bookShop;

        this.dialog.open(ViewBookshopModalComponent, dialogConfig);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }


  DeleteBookShop(id: string){
    this.bookShopService.DeleteBookshop(id)
    .subscribe({
      next: (response) => {
        console.log("Bookshop Deleted Successfully");

        for(var i=0; i < this.bookShops.length; i++){
          let bookShopObj = this.bookShops[i];

          if(bookShopObj.id === id){
            this.bookShops.splice(i, 1);
          }

          this.dataSource.data = this.bookShops;
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
