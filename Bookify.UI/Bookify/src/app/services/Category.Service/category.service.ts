import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from 'src/app/models/Category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  public AllCategory(){
    return this.http.get("api/Category");
  }

  public GetCategory(id: string){
    return this.http.get(`api/category/${id}`);
  }
}
