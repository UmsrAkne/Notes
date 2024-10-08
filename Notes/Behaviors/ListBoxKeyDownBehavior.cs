﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;
using Notes.Models;
using Notes.ViewModels;

namespace Notes.Behaviors
{
    public class ListBoxKeyDownBehavior : Behavior<ListBox>
    {
        private ScrollViewer scrollViewer;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.KeyDown += OnKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.KeyDown -= OnKeyDown;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            var listBox = sender as ListBox;

            var isShiftPressed = (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
            var isControlPressed = (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;

            if (listBox == null)
            {
                return;
            }

            var vm = ((MainWindowViewModel)listBox.DataContext).ScrapContainer;

            switch (e.Key)
            {
                case Key.G:
                    if (isShiftPressed)
                    {
                        vm.CursorManager.MoveCursorToBottom();
                        break;
                    }

                    vm.CursorManager.MoveCursorToTop();
                    break;
                case Key.J:
                    if (isShiftPressed && listBox.SelectedIndex < listBox.Items.Count - 1)
                    {
                        var index = listBox.SelectedIndex;
                        var item = listBox.SelectedItem as Scrap;
                        if (listBox.ItemsSource is ObservableCollection<Scrap> items)
                        {
                            items.RemoveAt(index);
                            items.Insert(index + 1, item);
                            listBox.SelectedIndex = index + 1;
                            listBox.SelectedItem = item;

                            // vm?.ReIndex(items);
                        }

                        break;
                    }

                    vm.CursorManager.MoveCursorDown();
                    break;

                case Key.K:
                    if (isShiftPressed && listBox.SelectedIndex > 0)
                    {
                        var index = listBox.SelectedIndex;
                        var item = listBox.SelectedItem as Scrap;
                        if (listBox.ItemsSource is ObservableCollection<Scrap> items)
                        {
                            items.RemoveAt(index);
                            items.Insert(index - 1, item);
                            listBox.SelectedIndex = index - 1;
                            listBox.SelectedItem = item;

                            // vm?.ReIndex(items);
                        }

                        break;
                    }

                    vm.CursorManager.MoveCursorUp();
                    break;

                case Key.N:
                    if (!isShiftPressed)
                    {
                        vm.CursorManager.MoveCursorToNextMark();
                    }
                    else
                    {
                        vm.CursorManager.MoveCursorToPrevMark();
                    }

                    break;

                case Key.Delete:
                    if (isControlPressed && listBox.SelectedIndex >= 0)
                    {
                        var index = listBox.SelectedIndex;
                        if (listBox.ItemsSource is ObservableCollection<Scrap> items)
                        {
                            items.RemoveAt(index);

                            // vm?.ReIndex(items);
                        }
                    }

                    break;

                case Key.D:
                    if (isControlPressed && listBox.SelectedIndex < listBox.Items.Count - 1)
                    {
                        MoveToPage(listBox, true);
                    }

                    break;

                case Key.U:
                    if (isControlPressed && listBox.SelectedIndex > 0)
                    {
                        MoveToPage(listBox, false);
                    }

                    break;
            }

            if (listBox.SelectedItem != null)
            {
                listBox.ScrollIntoView(listBox.SelectedItem);
            }
        }

        private ScrollViewer GetScrollViewer(DependencyObject o)
        {
            if (o is ScrollViewer viewer)
            {
                return viewer;
            }

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var child = VisualTreeHelper.GetChild(o, i);
                var result = GetScrollViewer(child);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        private void MoveToPage(ListBox listBox, bool isNext)
        {
            scrollViewer ??= GetScrollViewer(listBox);

            var moveCountPerPage = 0;
            if (listBox.Items.Count > 0)
            {
                var item = listBox.Items[0];
                if (item != null)
                {
                    listBox.ScrollIntoView(item);
                    if (listBox.ItemContainerGenerator.ContainerFromIndex(0) is FrameworkElement container)
                    {
                        moveCountPerPage = (int)(scrollViewer.ActualHeight / container.ActualHeight) - 1;
                    }
                }
            }

            var newIndex = listBox.SelectedIndex;
            newIndex += isNext ? moveCountPerPage : -moveCountPerPage;
            newIndex = Math.Max(0, Math.Min(newIndex, listBox.Items.Count - 1));
            listBox.SelectedIndex = newIndex;
        }
    }
}