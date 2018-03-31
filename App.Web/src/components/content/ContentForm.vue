<template>
  <div>
    <h1>Content {{ content.id }}</h1>
    <form>
      <div class="form-group">
        <label for="contentData">Data</label>
        <textarea v-model="content.data" class="form-control" id="contentData" rows="3"></textarea>
      </div>
      <div class="form-group">
        <label for="contentLookup">Lookup</label>
        <select class="form-control" id="contentLookup">
          <option>1</option>
          <option>2</option>
          <option>3</option>
          <option>4</option>
          <option>5</option>
        </select>
      </div>
      <button type="submit" class="btn btn-primary">Submit</button>
    </form>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'ContentForm',
  created: function() {
    this.$store.dispatch('getContent', this.$route.params.id);
  },
  computed: {
    ...mapGetters({
      content: 'currentContent',
    }),
  },
};
</script>

<style>

</style>
