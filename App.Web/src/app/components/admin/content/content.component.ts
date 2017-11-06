import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ContentService } from '../../../services/content.service';
import { Content } from '../../../interfaces/content';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit, OnDestroy {
  content: Content;
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
        if (this.id) {
          this.contentService.get(this.id).subscribe((res) => {
            this.content = res.json() as Content;
          });
        }
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

}
