const images = document.querySelectorAll('.gallery-item');
  const popup = document.querySelector('.popup');
  const popupImg = popup.querySelector('img');
  const closeBtn = popup.querySelector('.close');
  const prevBtn = popup.querySelector('.prev');
  const nextBtn = popup.querySelector('.next');
  let currentIndex = 0;

  const openPopup = (index) => {
    currentIndex = index;
    popupImg.src = images[currentIndex].src;
    popup.classList.add('active');
  };

  const closePopup = () => {
    popup.classList.remove('active');
  };

  const showNextImage = () => {
    currentIndex = (currentIndex + 1) % images.length;
    popupImg.src = images[currentIndex].src;
  };

  const showPrevImage = () => {
    currentIndex = (currentIndex - 1 + images.length) % images.length;
    popupImg.src = images[currentIndex].src;
  };

  images.forEach((img, index) => {
    img.addEventListener('click', () => openPopup(index));
  });

  closeBtn.addEventListener('click', closePopup);
  nextBtn.addEventListener('click', showNextImage);
  prevBtn.addEventListener('click', showPrevImage);

  popup.addEventListener('click', (e) => {
    if (e.target === popup) closePopup();
  });