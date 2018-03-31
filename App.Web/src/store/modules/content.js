import content from '../../api/content';

// initial state
// shape: [{ id, quantity }]
const state = {
  currentContent: {},
  contentList: [
    { id: 1, data: 'Here is some data!' },
    { id: 2, data: 'Here is some more data!!' },
  ],
};

// getters
const getters = {
  contentList: state => state.contentList,

  currentContent: state => state.currentContent,
};

// actions
const actions = {
  addContent({ commit }, newContent) {
    content.addContent(newContent).then((response) => {
      commit('pushContent', { item: response.body });
    });
  },

  getContent({ state, commit }, id) {
    console.log(`Retrieving content with id:${JSON.stringify(id)}...`);
    const item = state.contentList.find(value => value.id === Number(id));
    commit('setCurrentContent', { item });
  },

  getContentList({ commit }, page, max) {
    content.getContentList(page, max).then((response) => {
      commit('setContentList', { items: response.body });
    }, (reason) => {
      commit('setErrorMessage', reason);
    });
  },
};

// mutations
const mutations = {
  setContentList(state, { items }) {
    state.contentList = items;
  },

  pushContent(state, { item }) {
    state.contentList.push(item);
  },

  setCurrentContent(state, { item }) {
    state.currentContent = item;
  },

  incrementItemQuantity(state, { id }) {
    const cartItem = state.added.find(item => item.id === id);
    cartItem.quantity += 1;
  },

  setCartItems(state, { items }) {
    state.added = items;
  },

  setCheckoutStatus(state, status) {
    state.checkoutStatus = status;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
