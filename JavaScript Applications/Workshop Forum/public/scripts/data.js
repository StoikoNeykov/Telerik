var data = (function () {
  const USERNAME_STORAGE_KEY = 'username-key';

  // start users
  function userLogin(user) {
    localStorage.setItem(USERNAME_STORAGE_KEY, user);
    return Promise.resolve(user);
  }

  function userLogout() {
    localStorage.removeItem(USERNAME_STORAGE_KEY)
    return Promise.resolve();
  }

  function userGetCurrent() {
    return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
  }
  // end users

  // start threads
  function threadsGet() {
    return new Promise((resolve, reject) => {
      $.getJSON('api/threads')
        .done(resolve)
        .fail(reject);
    })
  }

  function threadsAdd(title) {
    let body = {
      "title": title
    }

    let promise = new Promise((resolve, reject) => {
      $.ajax({
        url: 'api/threads',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(body),
        success: (data) => {
          resolve(data);
          $('#btn-threads').trigger('click');
        },
        error: (err) => reject(err)
      })

    })

    return promise;
  }

  function threadById(id) {
    let promise = new Promise((resolve, reject) => {
      $.ajax({
        url: 'api/threads/' + id,
        method: 'GET',
        contentType: 'application/json',
        success: (data) => resolve(data),
        error: (err) => reject(JSON.stringify(err))
      })
    })

    return promise;
  }

  function threadsAddMessage(threadId, content) {
    let body = {
      "username": localStorage.getItem(USERNAME_STORAGE_KEY),
      "content": JSON.stringify(content)
    }

    let selector = `div[data-id ="${threadId}"]`

    let promise = new Promise((resolve, reject) => {
      $.ajax({
        url: 'api/threads/' + threadId + '/messages',
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(body),
        success: (data) => {
          resolve(data)
          $(`div[data-id ="${threadId}"] > div > h3 > a`).trigger('click');
        },
        error: (err) => reject(err)
      })
    })

    return promise;
  }
  // end threads

  // start gallery
  function galleryGet() {
    const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

    return new Promise((resolve, reject) => {
      $.ajax({
        url: REDDIT_URL,
        dataType: 'jsonp'
      })
        .done(resolve)
        .fail(reject);
    })
  }
  // end gallery

  return {
    users: {
      login: userLogin,
      logout: userLogout,
      current: userGetCurrent
    },
    threads: {
      get: threadsGet,
      add: threadsAdd,
      getById: threadById,
      addMessage: threadsAddMessage
    },
    gallery: {
      get: galleryGet,
    }
  }
})();