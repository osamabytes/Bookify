import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from 'src/app/models/Category.model';
import { CategoryService } from 'src/app/services/Category.Service/category.service';
import { ViewCategoryModalComponent } from '../../Modals/view-category-modal/view-category-modal.component';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements AfterViewInit {
  categoriesTableColumn: string[] = ['name', 'actions'];
  
  dataSource: MatTableDataSource<Category>;

  @ViewChild(MatPaginator) paginator: MatPaginator | any;
  @ViewChild(MatSort) sort: MatSort | any;

  categories: Category[] = [];

  constructor(private dialog: MatDialog, private categoryService: CategoryService) { 
    this.categories = categoryService.AllCategory();
    this.dataSource = new MatTableDataSource<Category>(this.categories);
  }
  
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
    let category: Category = this.categoryService.GetCategory(id);

    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = category;

    this.dialog.open(ViewCategoryModalComponent, dialogConfig);
  }
}
