import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Author } from 'src/app/models/Author.model';
import { AuthorService } from 'src/app/services/Author.Service/author.service';

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

  constructor(private activatedRoute: ActivatedRoute, private authorService: AuthorService) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if(id){
          this.author = this.authorService.GetAuthor(id);
        }
      }
    });
  }

  AddAuthor(addauthorform: NgForm){
  }

}
