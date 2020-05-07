from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC

driver = webdriver.Chrome()
driver.get("https://www.google.com")
driver.switch_to.active_element.send_keys('unit testing', Keys.ENTER)

print("Открылись результаты поиска в гугле")

# у этих элементов (плашка с href ссылков) класс "r"
# дерево div-ов скорее поменятся может, чем класс
elements = driver.find_elements_by_xpath("/html/body/div/div/div/div/div/div/div/div/div/div/div/div/div/a")

for i in elements:
    link = i.get_attribute("href")
    if link.find("en.wikipedia.org") != -1:
        driver.get(link)
        print("Нашли ссылку на англ. википедию")
        break

# вбиваем в поиск и из выпадающего списка берем первое предложенное из "плашки"
# не самая надежная вещь, тут опирается на ajax-запрос 
# Надежней было бы:
# 1) вбить в поиск + Enter
# 2) откроется новая страница списка результатов.
# 3) И из этого списка уже находить уже первое предложенное.
driver.find_element_by_id("searchInput").send_keys("NUnit")

wait = WebDriverWait(driver, 10)
# до 10 сек ждем пока появится плашка предложений по поиску (ajax)
wait.until(EC.element_to_be_clickable((By.CLASS_NAME, 'suggestions')))
driver.find_element_by_id("searchInput").send_keys(Keys.ARROW_DOWN, Keys.ENTER)

if str(driver.current_url) == "https://en.wikipedia.org/wiki/NUnit":
    print("URL совпадает с заданием")
else:
    print("URL НЕ совпадает с заданием")

langs = driver.find_elements_by_class_name("interlanguage-link")
for langElement in langs:
    codeLang = langElement.find_element_by_class_name("interlanguage-link-target").get_attribute("lang")
    if (codeLang == "ru"):
        print("Есть русская ссылка")
        break

print("Конец")
# driver.close()