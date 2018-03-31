import Vue from 'vue';
import Router from 'vue-router';
import HelloWorld from '@/components/HelloWorld';
import ContentHeader from '@/components/content/ContentHeader';
import ContentList from '@/components/content/ContentList';
import ContentForm from '@/components/content/ContentForm';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HelloWorld',
      component: HelloWorld,
    },
    {
      path: '/content',
      name: 'ContentList',
      component: ContentHeader,
      children: [
        {
          path: '',
          name: 'ContentList',
          component: ContentList,
        },
        {
          path: ':id',
          name: 'EditContent',
          component: ContentForm,
        },
      ],
    },
  ],
});
