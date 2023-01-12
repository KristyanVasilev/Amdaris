import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Publication } from 'src/app/models/publication';
import { PublicationService } from 'src/app/services/publication.service';

@Component({
  selector: 'app-delete-publication',
  templateUrl: './delete-publication.component.html',
  styleUrls: ['./delete-publication.component.css']
})
export class DeletePublicationComponent {
  @ViewChild('publicationFindForm') publicationFindForm: any;
  submitted: boolean = false;
  publicationSubsription: Subscription | undefined;
  publication!: Publication;
  publicationId = {
    id: 0,
  };
  publicationName = {
    name: '',
  };

  constructor(
    private publicationService: PublicationService,
    private router: Router) {

  }

  deletePublication() {
    this.publicationSubsription = this.publicationService
      .deletePublication(this.publicationId.id)
      .subscribe((res) => {
        console.log(res)
      });
    this.router.navigate(['home']);
  }

  FindPublication() {
    this.publicationSubsription = this.publicationService
      .findPublication(this.publicationName.name)
      .subscribe((_publication) => {
        this.publication = _publication;
        console.log(_publication)
      });
    this.resetForm();
  }

  resetForm() {
    this.publicationName = { name: "" };
    this.publication = { id: 0, name: '', price: 0, pageCount: 0, description: '', genre: '', author: '', images: [] };
    this.publicationFindForm.resetForm();
    this.submitted = false;
  }

  ngOnDestroy(): void {
    if (this.publicationSubsription) {
      this.publicationSubsription.unsubscribe();
    }
  }
}
