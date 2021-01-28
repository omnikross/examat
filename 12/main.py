from urllib.request import urlopen as uReq
from bs4 import BeautifulSoup
import requests
import json


url = 'https://www.wego.com/flights/ams/nyc/cheapest-flights-from-amsterdam-339-to-new-york-city'

html_text = """
<span class="bar js-has-tooltip js-button</span>
"""

html = BeautifulSoup(html_text, "lxml")

spans = html.find_all('span', {'class': 'bar js-has-tooltip js-button'})
for span in spans:
    print(span.text.replace('USD', '').strip())


price=a.find('div', attrs={'class':'_1vD41E _3rQ-WK'})
prices.append(price.text)
df = pd.DataFrame({'Product Name':products,'Price':prices,'Rating':ratings}) 
df.to_csv('products.csv', index=False, encoding='utf-8')
