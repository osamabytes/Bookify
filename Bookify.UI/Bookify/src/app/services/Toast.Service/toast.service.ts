import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(private snakbar: MatSnackBar) { }

  public openToast(duration: number, data: any, type: string){

    let className = "";

    if(type === "primary"){
      className = 'primarytoast';
    }else if(type === "danger"){
      className = 'dangertoast';
    }else if(type === "success"){
      className = 'successtoast';
    }

    this.snakbar.open(data, 'Close', {
      duration: (duration * 1000),
      panelClass: [className]
    })
  }
}
