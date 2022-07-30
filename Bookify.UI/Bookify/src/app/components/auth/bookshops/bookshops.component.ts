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

  dataSource: MatTableDataSource<Bookshop>;

  @ViewChild(MatPaginator) paginator : MatPaginator | any;
  @ViewChild(MatSort) sort : MatSort | any;

  bookShops: Bookshop[] = [];

  constructor(private dialog: MatDialog, private bookShopService: BookshopService) { 
    this.bookShops = bookShopService.AllBookshops();
    this.dataSource = new MatTableDataSource<Bookshop>(this.bookShops);
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

  openViewDialog(id: string){
    let bookShop: Bookshop = this.bookShopService.GetBookShop(id);

    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = bookShop;

    this.dialog.open(ViewBookshopModalComponent, dialogConfig);
  }
}
