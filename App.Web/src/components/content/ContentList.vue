<template>
<div>
  <h1>Content List</h1>
  <table class="table">
      <thead>
          <tr>
              <th>#</th>
              <th>Data</th>
          </tr>
      </thead>
      <tbody>
          <tr v-for="content in contentList" v-bind:key="content.id">
              <th>{{ content.id }}</th>
              <td>
                {{ content.data }}
                <router-link class="btn btn-dark float-right" :to="`content/${ content.id }`">Edit</router-link>
              </td>
          </tr>
      </tbody>
  </table>
</div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'ContentList',
  created: function() {
    //this.$store.dispatch('getContentList');
  },

  computed: {
    ...mapGetters({
      contentList: 'contentList',
    }),
  },
  methods: {
    checkout(products) {
      this.$store.dispatch('checkout', products);
    },
  },
};
</script>

<style>

</style>
