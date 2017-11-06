import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ContentService } from "../../services/content.service";

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
  id: number;
  private sub: any;
  
  constructor(
    private route: ActivatedRoute,
    private contentService: ContentService
  ) {}
  
  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
        this.id = +params['id']; // (+) converts string 'id' to a number

        // In a real app: dispatch action to load the details here.
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
