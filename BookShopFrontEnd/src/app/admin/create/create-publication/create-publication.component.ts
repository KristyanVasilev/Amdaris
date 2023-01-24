import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, throwError } from 'rxjs';
import { Publication } from 'src/app/models/publication';
import { PublicationService } from 'src/app/services/publication.service';

@Component({
  selector: 'app-create-publication',
  templateUrl: './create-publication.component.html',
  styleUrls: ['./create-publication.component.css']
})
export class CreatePublicationComponent {
  publication: Publication = { id: 0, name: '', price: 0, description: '', genre: '', author: '', pageCount:0, images: [] as string[], keyWords: '', quantity: 0};
  isUploaded = false;
  shortLink: string = "";
  loading: boolean = false;
  file?: File;

  constructor(
    private http: HttpClient,
    private router: Router,
    private publicationService: PublicationService) { }

  upload(file: any): Observable<any> {
    const formData = new FormData();
    formData.append("file", file, file.name);
    this.isUploaded = true;
    return this.http.post('https://localhost:7201/api/Files/Images', formData)
  }

  onChange(event: any) {

    this.file = event.target.files[0];
  }

  onUpload() {

    this.loading = !this.loading;
    console.log(this.file);

    this.upload(this.file).subscribe(
      (event: any) => {
        console.log(event);
        console.log(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        this.publication.images.push(JSON.stringify(event).substring(10, JSON.stringify(event).length - 3));
        if (typeof (event) === 'object') {
          this.shortLink = event.link;
          this.loading = false; // Flag variable
        }
      }
    );
  }

  createPublication() {
    this.publicationService.createPublication(this.publication)
    .subscribe(res => console.log(res));
    this.router.navigate(['home'])
  }
}
