import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';

import { Content } from '../interfaces/content';

@Injectable()
export class ContentService {

  constructor(
    private http: Http,
    @Inject('BASE_URL') private baseUrl: string
  ) {
    this.baseUrl = this.baseUrl + 'api/content';
  }

  getAll() {
    return this.http.get(this.baseUrl);
  }

  get(id: number) {
    return this.http.get(this.baseUrl + id);
  }

  add(content: Content) {
    return this.http.post(this.baseUrl, content);
  }
}
