import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetDataInterface } from '../interfaces/get-data.interface';
import { GraClass } from '../classes/gra.class';

@Injectable()
export class GryHttpService implements GetDataInterface {
  private readonly apiUrl = 'http://localhost:5104/api/Gry';

  constructor(private http: HttpClient) {}

  Get(): Observable<GraClass[]> {
    return this.http.get<GraClass[]>(this.apiUrl);
  }

  GetByID(id: number): Observable<GraClass> {
    return this.http.get<GraClass>(`${this.apiUrl}/${id}`);
  }
}