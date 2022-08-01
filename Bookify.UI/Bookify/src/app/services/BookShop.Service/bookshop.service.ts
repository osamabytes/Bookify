import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Bookshop } from 'src/app/models/Bookshop.model';

@Injectable({
  providedIn: 'root'
})
export class BookshopService {

  constructor(private http: HttpClient) { }

  public AllBookshops(): Observable<Bookshop[]>{
    return this.http.get<Bookshop[]>("api/Bookshop/AllUserBookshop");
  }

  public AddBookShop(body: Bookshop): Observable<Bookshop>{
    return this.http.post<Bookshop>("api/Bookshop", body);
  }

  public UpdateBookShop(body: Bookshop): Observable<Bookshop>{
    return this.http.put<Bookshop>("api/Bookshop", body);
  }

  public DeleteBookshop(id: string){
    return this.http.delete(`api/Bookshop/${id}`);
  }

  public GetBookShop(id: string): Observable<Bookshop>{
    return this.http.get<Bookshop>(`api/Bookshop/${id}`);
  }
}
