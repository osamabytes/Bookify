import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from '@angular/material/table';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSelectModule } from '@angular/material/select';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';



import { SidebarComponent } from './components/index/sidebar/sidebar.component';
import { NavbarComponent } from './components/index/navbar/navbar.component';
import { LoginComponent } from './components/index/login/login.component';
import { RegisterComponent } from './components/index/register/register.component';
import { HomeComponent } from './components/index/home/home.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfirmationComponent } from './components/index/confirmation/confirmation.component';
import { AboutusComponent } from './components/index/aboutus/aboutus.component';
import { DashboardComponent } from './components/auth/dashboard/dashboard.component';
import { AuthSideBarComponent } from './components/auth/auth-side-bar/auth-side-bar.component';
import { AuthNavbarComponent } from './components/auth/auth-navbar/auth-navbar.component';
import { BooksComponent } from './components/auth/books/books.component';
import { BookshopsComponent } from './components/auth/bookshops/bookshops.component';
import { AuthorsComponent } from './components/auth/authors/authors.component';
import { CategoriesComponent } from './components/auth/categories/categories.component';
import { AddBookComponent } from './components/auth/add-book/add-book.component';
import { AddBookshopComponent } from './components/auth/add-bookshop/add-bookshop.component';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    ConfirmationComponent,
    AboutusComponent,
    DashboardComponent,
    AuthSideBarComponent,
    AuthNavbarComponent,
    BooksComponent,
    BookshopsComponent,
    AuthorsComponent,
    CategoriesComponent,
    AddBookComponent,
    AddBookshopComponent,
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatStepperModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule,
    MatExpansionModule,
    MatTableModule,
    MatSnackBarModule,
    MatSelectModule,
    MatPaginatorModule,
    MatSortModule,
    MatSlideToggleModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
