import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';

import { Lookup } from '../interfaces/lookup';

@Injectable()
export class LookupService {

  constructor(
    private http: Http,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.baseUrl = this.baseUrl + 'api/lookup';
  }

  getAll() {
    return this.http.get(this.baseUrl);
  }

  get(id: number) {
    return this.http.get(this.baseUrl + id);
  }

  add(content: Lookup) {
    return this.http.post(this.baseUrl, content);
  }
}
