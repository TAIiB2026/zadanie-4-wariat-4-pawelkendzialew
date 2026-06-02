import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormSubmitInterface } from '../interfaces/form-submit.interface';

@Injectable()
export class FormularzHttpService implements FormSubmitInterface {
  private readonly apiUrl = 'http://localhost:5104/api/Gry';

  constructor(private http: HttpClient) {}

  Post(nazwa: string, cena: number, data: Date): Observable<boolean> {
    return this.http.post<boolean>(this.apiUrl, {
      tytul: nazwa,
      cena: cena,
      dataPremiery: data
    });
  }

  Put(id: number, nazwa: string, cena: number, data: Date): Observable<boolean> {
    return this.http.put<boolean>(`${this.apiUrl}/${id}`, {
      tytul: nazwa,
      cena: cena,
      dataPremiery: data
    });
  }
}