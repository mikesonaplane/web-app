import Vue from 'vue';
import Vuex from 'vuex';
import content from './modules/content';
import lookups from './modules/lookups';

Vue.use(Vuex);

const debug = process.env.NODE_ENV !== 'production';

export default new Vuex.Store({
  modules: {
    content,
    lookups,
  },
  strict: debug,
});
