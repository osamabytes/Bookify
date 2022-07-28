import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/auth/dashboard/dashboard.component';
import { AboutusComponent } from './components/index/aboutus/aboutus.component';
import { ConfirmationComponent } from './components/index/confirmation/confirmation.component';
import { HomeComponent } from './components/index/home/home.component';
import { LoginComponent } from './components/index/login/login.component';
import { RegisterComponent } from './components/index/register/register.component';

const routes: Routes = [
  // Default Sidebar Nav Components
  {
    path: "",
    component: HomeComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      },
      {
        path: 'aboutus',
        component: AboutusComponent
      },
      {
        path: 'confirm',
        component: ConfirmationComponent
      }
    ]
  },
  // Auth Routes
  {
    path: "auth",
    component: DashboardComponent,
    children: [
    ]
  },
  // Default Routes
  {path: "", component: HomeComponent},
  {path: "**", redirectTo: "", pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
