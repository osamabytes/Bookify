import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from 'src/app/models/Author.model';
import { AuthorService } from 'src/app/services/Author.Service/author.service';
import { ToastService } from 'src/app/services/Toast.Service/toast.service';

@Component({
  selector: 'app-add-author',
  templateUrl: './add-author.component.html',
  styleUrls: ['./add-author.component.css']
})
export class AddAuthorComponent implements OnInit {

  author: Author = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    description: ''
  };

  authorName = new FormControl('', [Validators.required]);

  constructor(private activatedRoute: ActivatedRoute, private toastService: ToastService, private authorService: AuthorService, private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.authorService.GetAuthor(id)
          .subscribe({
            next: (author) => {
              this.author = author;
              console.log(this.author);
            },
            error: (err) => {
              console.log(err);
            }
          });
        }
      }
    });
  }

  getAuthorNameError(){
    if(this.authorName.hasError('required')){
      return 'Author Name is Required';
    }

    return '';
  }

  AddAuthor(addauthorform: NgForm){
    if(this.author.id !== '' && this.author.id !== '00000000-0000-0000-0000-000000000000'){
      this.authorService.Update(this.author)
      .subscribe({
        next: (author) => {
          addauthorform.reset();

          this.toastService.openToast(2, "Author Updated Successfully", "success");

          this.router.navigate(['', 'auth', 'authors']);
        },
        error: (err) => {
          if(err.error.hasOwnProperty('errors')){
            var errors = err.error.errors;

            for(var property in errors){
              let errorList = errors[property];

              errorList.forEach((item: any) => {
                this.toastService.openToast(3, item, "danger");
              });
            }
          }

          if(err.status === 400){
            this.toastService.openToast(3, "Bad Request", "danger");
          }
        }
      })
    }else{
      this.authorService.Add(this.author)
      .subscribe({
        next: (author) => {
          addauthorform.reset();

          this.toastService.openToast(2, "Author Added Successfully", "success");

          this.router.navigate(['', 'auth', 'authors']);
        },
        error: (err) => {
          console.log(err);

          if(err.error.hasOwnProperty('errors')){
            var errors = err.error.errors;

            for(var property in errors){
              let errorList = errors[property];

              errorList.forEach((item: any) => {
                this.toastService.openToast(3, item, "danger");
              });
            }
          }

          if(err.status === 400){
            this.toastService.openToast(3, "Bad Request", "danger");
          }
        }
      });
    }
  }

}
