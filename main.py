import os
import shutil
from datetime import datetime

SAVE_PATH = r"C:\Users\user\AppData\Roaming\StardewValley\Saves\юля_424103767\юля_424103767"

def create_backup(path: str):
    timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
    backup_path = f"{path}.backup_{timestamp}"
    shutil.copy2(path, backup_path)
    print(f"Создана резервная копия: {backup_path}")
    return backup_path


def find_and_modify_value(content: str, tag_name: str, new_value: str):
    player_start = content.find('<player>')
    player_end = content.find('</player>')

    if player_start == -1 or player_end == -1:
        print("Не найдена секция player!")
        return None

    player_section = content[player_start:player_end]

    start_tag = f'<{tag_name}>'
    end_tag = f'</{tag_name}>'

    tag_start = player_section.find(start_tag)
    if tag_start == -1:
        print(f"Не найден тег {tag_name}!")
        return None

    tag_end = player_section.find(end_tag, tag_start)
    if tag_end == -1:
        print(f"Не найден закрывающий тег для {tag_name}!")
        return None

    value_start = tag_start + len(start_tag)
    value_end = tag_end

    old_value = player_section[value_start:value_end]
    print(f"Старое значение {tag_name}: {old_value}")

    new_player_section = (
            player_section[:value_start] +
            str(new_value) +
            player_section[value_end:]
    )

    new_content = (
            content[:player_start] +
            new_player_section +
            content[player_end:]
    )

    print(f"Новое значение {tag_name}: {new_value}")
    return new_content


def show_current_values(content: str):
    print("\nТЕКУЩИЕ ЗНАЧЕНИЯ")

    tags_to_show = [
        'money', 'health', 'maxHealth', 'stamina', 'maxStamina',
        'farmingLevel', 'miningLevel', 'combatLevel', 'foragingLevel',
        'fishingLevel', 'luckLevel', 'maxItems'
    ]

    player_start = content.find('<player>')
    player_end = content.find('</player>')

    if player_start != -1 and player_end != -1:
        player_section = content[player_start:player_end]

        for tag in tags_to_show:
            start_tag = f'<{tag}>'
            end_tag = f'</{tag}>'

            tag_start = player_section.find(start_tag)
            if tag_start != -1:
                tag_end = player_section.find(end_tag, tag_start)
                if tag_end != -1:
                    value_start = tag_start + len(start_tag)
                    value_end = tag_end
                    value = player_section[value_start:value_end]
                    print(f"{tag}: {value}")


def main():
    print("=== Stardew Valley Save Editor ===")

    if not os.path.exists(SAVE_PATH):
        print(f"Файл сохранения не найден: {SAVE_PATH}")
        return

    backup_path = create_backup(SAVE_PATH)

    with open(SAVE_PATH, 'r', encoding='utf-8') as f:
        content = f.read()

    show_current_values(content)

    print("\nВАРИАНТЫ ИЗМЕНЕНИЯ")
    print("1 - Деньги (money)")
    print("2 - Здоровье (health и maxHealth)")
    print("3 - Энергия (stamina и maxStamina)")
    print("4 - Уровни всех навыков")
    print("5 - Улучшение рюкзака")
    print("6 - Всё сразу (деньги, здоровье, энергия, навыки)")
    print("7 - Бессмертие (9999 здоровья и энергии)")
    print("8 - Максимум всего")

    choice = input("Выбери вариант (1-8): ").strip()

    new_content = content

    try:
        if choice == "1":
            money = int(input("Новое количество денег: ").strip())
            new_content = find_and_modify_value(content, 'money', money)

        elif choice == "2":
            health = int(input("Новое значение здоровья: ").strip())
            new_content = find_and_modify_value(content, 'health', health)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxHealth', health)

        elif choice == "3":
            stamina = int(input("Новое значение энергии: ").strip())
            new_content = find_and_modify_value(content, 'stamina', stamina)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxStamina', stamina)

        elif choice == "4":
            level = int(input("Новый уровень всех навыков (0-10): ").strip())
            if 0 <= level <= 10:
                skills = ['farmingLevel', 'miningLevel', 'combatLevel', 'foragingLevel', 'fishingLevel', 'luckLevel']
                new_content = content
                for skill in skills:
                    new_content = find_and_modify_value(new_content, skill, level)
            else:
                print("Уровень должен быть от 0 до 10!")
                return

        elif choice == "5":
            upgrade = int(input("Уровень улучшения рюкзака (0-базовый, 1-средний, 2-большой): ").strip())
            if upgrade == 0:
                new_content = find_and_modify_value(content, 'maxItems', 12)
            elif upgrade == 1:
                new_content = find_and_modify_value(content, 'maxItems', 24)
            elif upgrade == 2:
                new_content = find_and_modify_value(content, 'maxItems', 36)
            else:
                print("Уровень должен быть от 0 до 2!")
                return

        elif choice == "6":
            money = int(input("Новое количество денег: ").strip())
            health = int(input("Новое значение здоровья: ").strip())
            stamina = int(input("Новое значение энергии: ").strip())
            level = int(input("Новый уровень навыков (0-10): ").strip())

            new_content = find_and_modify_value(content, 'money', money)
            if new_content:
                new_content = find_and_modify_value(new_content, 'health', health)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxHealth', health)
            if new_content:
                new_content = find_and_modify_value(new_content, 'stamina', stamina)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxStamina', stamina)
            if new_content and 0 <= level <= 10:
                skills = ['farmingLevel', 'miningLevel', 'combatLevel', 'foragingLevel', 'fishingLevel', 'luckLevel']
                for skill in skills:
                    new_content = find_and_modify_value(new_content, skill, level)

        elif choice == "7":
            new_content = find_and_modify_value(content, 'health', 9999)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxHealth', 9999)
            if new_content:
                new_content = find_and_modify_value(new_content, 'stamina', 9999)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxStamina', 9999)

        elif choice == "8":
            new_content = find_and_modify_value(content, 'money', 9999999)
            if new_content:
                new_content = find_and_modify_value(new_content, 'health', 999)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxHealth', 999)
            if new_content:
                new_content = find_and_modify_value(new_content, 'stamina', 999)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxStamina', 999)
            if new_content:
                skills = ['farmingLevel', 'miningLevel', 'combatLevel', 'foragingLevel', 'fishingLevel', 'luckLevel']
                for skill in skills:
                    new_content = find_and_modify_value(new_content, skill, 10)
            if new_content:
                new_content = find_and_modify_value(new_content, 'maxItems', 36)

        else:
            print("Неверный выбор.")
            return

    except ValueError:
        print("Нужно вводить целые числа!")
        return

    if new_content and new_content != content:
        with open(SAVE_PATH, 'w', encoding='utf-8') as f:
            f.write(new_content)
        print("\nИзменения успешно применены!")
    else:
        print("\nНе удалось применить изменения")


if __name__ == "__main__":
    main()
